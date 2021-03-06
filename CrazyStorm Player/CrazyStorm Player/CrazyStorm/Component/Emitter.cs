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
    abstract class Emitter : Component
    {
        public Vector2 EmitPosition { get; set; }
        public int EmitCount { get; set; }
        public int EmitCycle { get; set; }
        public float EmitAngle { get; set; }
        public float EmitRange { get; set; }
        public float EmitRadius { get; set; }
        public ParticleBase InitialTemplate { get; protected set; }
        public ParticleBase Template { get; protected set; }
        public LinkedList<ParticleBase> Particles { get; private set; }
        public IList<EventGroup> EmitterEventGroups { get; private set; }
        public Emitter()
        {
            Particles = new LinkedList<ParticleBase>();
            EmitterEventGroups = new List<EventGroup>();
        }
        public override void LoadPlayData(BinaryReader reader, float version)
        {
            base.LoadPlayData(reader, version);
            using (BinaryReader emitterReader = PlayDataHelper.GetBlockReader(reader))
            {
                using (BinaryReader dataReader = PlayDataHelper.GetBlockReader(emitterReader))
                {
                    EmitPosition = PlayDataHelper.ReadVector2(dataReader);
                    EmitCount = dataReader.ReadInt32();
                    EmitCycle = dataReader.ReadInt32();
                    EmitAngle = dataReader.ReadSingle();
                    EmitRange = dataReader.ReadSingle();
                    EmitRadius = dataReader.ReadSingle();
                }
                //particle
                InitialTemplate.LoadPlayData(emitterReader, version);
                InitialTemplate.Emitter = this;
                //emitterEventGroups
                PlayDataHelper.LoadObjectList(EmitterEventGroups, emitterReader, version);
                InitialTemplate.ParticleEventGroups = EmitterEventGroups;
            }
        }
        public override bool PushProperty(string propertyName)
        {
            if (base.PushProperty(propertyName))
                return true;

            switch (propertyName)
            {
#if GENERATE_SNIPPET
                case "EmitPosition": 
                    VM.PushVector2(EmitPosition);
                    return true;
                case "EmitPosition.x":
                    VM.PushFloat(EmitPosition.x);
                    return true;
                case "EmitPosition.y":
                    VM.PushFloat(EmitPosition.y);
                    return true;
                case "EmitCount":
                    VM.PushInt(EmitCount);
                    return true;
                case "EmitCycle":
                    VM.PushInt(EmitCycle);
                    return true;
                case "EmitAngle":
                    VM.PushFloat(EmitAngle);
                    return true;
                case "EmitRange":
                    VM.PushFloat(EmitRange);
                    return true;
                case "EmitRadius":
                    VM.PushFloat(EmitRadius);
                    return true;
#endif
            }
            return Template.PushProperty(propertyName);
        }
        public override bool SetProperty(string propertyName)
        {
            if (base.SetProperty(propertyName))
                return true;

            switch (propertyName)
            {
#if GENERATE_SNIPPET
                case "EmitPosition":
                    EmitPosition = VM.PopVector2();
                    return true;
                case "EmitPosition.x":
                    EmitPosition = new Vector2(VM.PopFloat(), EmitPosition.y);
                    return true;
                case "EmitPosition.y":
                    EmitPosition = new Vector2(EmitPosition.x, VM.PopFloat());
                    return true;
                case "EmitCount":
                    EmitCount = VM.PopInt();
                    return true;
                case "EmitCycle":
                    EmitCycle = VM.PopInt();
                    return true;
                case "EmitAngle":
                    EmitAngle = VM.PopFloat();
                    return true;
                case "EmitRange":
                    EmitRange = VM.PopFloat();
                    return true;
                case "EmitRadius":
                    EmitRadius = VM.PopFloat();
                    return true;
#endif
            }
            return Template.SetProperty(propertyName);
        }
        public override bool Update(int currentFrame)
        {
            if (!base.Update(currentFrame))
                return false;

            if (BindingTarget == null || CheckCircularBinding())
                EmitCyclically();
            else
                BindingUpdate(EmitCyclically);

            return true;
        }
        public override void Reset()
        {
            base.Reset();
            var initialState = base.initialState as Emitter;
            EmitPosition = initialState.EmitPosition;
            EmitCount = initialState.EmitCount;
            EmitCycle = initialState.EmitCycle;
            EmitAngle = initialState.EmitAngle;
            EmitRange = initialState.EmitRange;
            EmitRadius = initialState.EmitRadius;
            Template = InitialTemplate.Copy();
        }
        public void EmitParticle()
        {
            if (BindingTarget == null || CheckCircularBinding())
                Emit();
            else
                BindingUpdate(Emit);
        }
        void EmitCyclically()
        {
            if (CurrentFrame % EmitCycle == 0)
                Emit();
        }
        void Emit()
        {
            base.ExecuteExpression("EmitCycle");
            base.ExecuteExpression("EmitRange");
            base.ExecuteExpression("EmitCount");
            base.ExecuteExpression("EmitAngle");
            base.ExecuteExpression("EmitPosition");
            base.ExecuteExpression("EmitRadius");
            Template.ExecuteExpressions();
            float increment = EmitRange / EmitCount;
            float angle = EmitAngle - (EmitRange + increment) / 2;
            for (int i = 0; i < EmitCount; ++i)
            {
                angle += increment;
                Template.PPosition = new Vector2(
                    EmitPosition.x + EmitRadius * (float)Math.Cos(MathHelper.DegToRad(angle)),
                    EmitPosition.y + EmitRadius * (float)Math.Sin(MathHelper.DegToRad(angle)));
                Template.PSpeedAngle = angle;
                ParticleBase newParticle = ParticleManager.GetParticle(Template);
                newParticle.ParticleEventGroups = EmitterEventGroups;
                Particles.AddLast(newParticle);
            }
        }
    }
}
