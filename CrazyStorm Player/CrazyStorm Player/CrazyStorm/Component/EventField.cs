﻿/*
 * The MIT License (MIT)
 * Copyright (c) StarX 2016
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CrazyStorm.Core;

namespace CrazyStorm_Player.CrazyStorm
{
    public enum FieldShape
    {
        Rectangle,
        Circle
    }
    public enum Reach
    {
        All,
        Layer,
        Name
    }
    class EventField : Component
    {
        public float HalfWidth { get; set; }
        public float HalfHeight { get; set; }
        public FieldShape FieldShape { get; set; }
        public Reach Reach { get; set; }
        public string TargetName { get; set; }
        public IList<EventGroup> EventFieldEventGroups { get; private set; }
        public EventField()
        {
            EventFieldEventGroups = new List<EventGroup>();
        }
        public override void LoadPlayData(BinaryReader reader, float version)
        {
            base.LoadPlayData(reader, version);
            using (BinaryReader eventFieldReader = PlayDataHelper.GetBlockReader(reader))
            {
                using (BinaryReader dataReader = PlayDataHelper.GetBlockReader(eventFieldReader))
                {
                    HalfWidth = dataReader.ReadSingle();
                    HalfHeight = dataReader.ReadSingle();
                    FieldShape = PlayDataHelper.ReadEnum<FieldShape>(dataReader);
                    Reach = PlayDataHelper.ReadEnum<Reach>(dataReader);
                    TargetName = PlayDataHelper.ReadString(dataReader);
                }
                //eventFieldEventGroups
                PlayDataHelper.LoadObjectList(EventFieldEventGroups, eventFieldReader, version);
            }
        }
        public override bool PushProperty(string propertyName)
        {
            if (base.PushProperty(propertyName))
                return true;

            switch (propertyName)
            {
#if GENERATE_SNIPPET
                case "HalfWidth":
                    VM.PushFloat(HalfWidth);
                    return true;
                case "HalfHeight":
                    VM.PushFloat(HalfHeight);
                    return true;
                case "FieldShape":
                    VM.PushEnum((int)FieldShape);
                    return true;
                case "Reach":
                    VM.PushEnum((int)Reach);
                    return true;
                case "TargetName":
                    VM.PushString(TargetName);
                    return true;
#endif
            }
            return false;
        }
        public override bool SetProperty(string propertyName)
        {
            if (base.SetProperty(propertyName))
                return true;

            switch (propertyName)
            {
#if GENERATE_SNIPPET
                case "HalfWidth":
                    HalfWidth = VM.PopFloat();
                    return true;
                case "HalfHeight":
                    HalfHeight = VM.PopFloat();
                    return true;
                case "FieldShape":
                    FieldShape = (FieldShape)VM.PopEnum();
                    return true;
                case "Reach":
                    Reach = (Reach)VM.PopEnum();
                    return true;
                case "TargetName":
                    TargetName = VM.PopString();
                    return true;
#endif
            }
            return false;
        }
        public override bool Update(int currentFrame)
        {
            if (!base.Update(currentFrame))
                return false;

            if (BindingTarget == null)
                Update();
            else
                BindingUpdate(Update);

            return true;
        }
        public override void Reset()
        {
            base.Reset();
            var initialState = base.initialState as EventField;
            HalfWidth = initialState.HalfWidth;
            HalfHeight = initialState.HalfHeight;
            FieldShape = initialState.FieldShape;
            Reach = initialState.Reach;
            TargetName = initialState.TargetName;
        }
        void Update()
        {
            base.ExecuteExpression("HalfWidth");
            base.ExecuteExpression("HalfHeight");
            List<ParticleBase> results = ParticleManager.SearchByRect(Position.x - HalfWidth, Position.x + HalfWidth,
                Position.y - HalfHeight, Position.y + HalfHeight);
            foreach (Particle particle in results)
            {
                if (particle.IgnoreMask)
                    continue;

                switch (Reach)
                {
                    case Reach.Layer:
                        if (particle.Emitter.LayerName != TargetName && particle.Emitter.LayerName != LayerName)
                            continue;

                        break;
                    case Reach.Name:
                        if (particle.Emitter.Name != TargetName)
                            continue;

                        break;
                }
                if (FieldShape == FieldShape.Circle)
                {
                    Vector2 v = Position - particle.PPosition;
                    if (Math.Sqrt(v.x * v.x + v.y * v.y) > HalfWidth)
                        continue;
                }
                for (int i = 0; i < EventFieldEventGroups.Count; ++i)
                    EventFieldEventGroups[i].Execute(particle);
            }
        }
    }
}
