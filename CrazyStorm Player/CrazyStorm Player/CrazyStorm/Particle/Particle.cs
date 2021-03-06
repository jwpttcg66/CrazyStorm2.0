﻿/*
 * The MIT License (MIT)
 * Copyright (c) StarX 2016
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CrazyStorm_Player.CrazyStorm
{
    class Particle : ParticleBase
    {
        public bool StickToSpeedAngle { get; set; }
        public float HeightScale { get; set; }
        public bool RetainScale { get; set; }
        public bool AfterimageEffect { get; set; }
        public override void LoadPlayData(BinaryReader reader, float version)
        {
            base.LoadPlayData(reader, version);
            using (BinaryReader particleReader = PlayDataHelper.GetBlockReader(reader))
            {
                using (BinaryReader dataReader = PlayDataHelper.GetBlockReader(particleReader))
                {
                    StickToSpeedAngle = dataReader.ReadBoolean();
                    HeightScale = dataReader.ReadSingle();
                    RetainScale = dataReader.ReadBoolean();
                    AfterimageEffect = dataReader.ReadBoolean();
                }
            }
        }
        public override bool PushProperty(string propertyName)
        {
            if (base.PushProperty(propertyName))
                return true;

            switch (propertyName)
            {
#if GENERATE_SNIPPET
                case "StickToSpeedAngle":
                    VM.PushBool(StickToSpeedAngle);
                    return true;
                case "HeightScale":
                    VM.PushFloat(HeightScale);
                    return true;
                case "RetainScale":
                    VM.PushBool(RetainScale);
                    return true;
                case "AfterimageEffect":
                    VM.PushBool(AfterimageEffect);
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
                case "StickToSpeedAngle":
                    StickToSpeedAngle = VM.PopBool();
                    return true;
                case "HeightScale":
                    HeightScale = VM.PopFloat();
                    return true;
                case "RetainScale":
                    RetainScale = VM.PopBool();
                    return true;
                case "AfterimageEffect":
                    AfterimageEffect = VM.PopBool();
                    return true;
#endif
            }
            return false;
        }
        public override void Update()
        {
            base.Update();
            if (StickToSpeedAngle)
                PRotation = PSpeedAngle + 90;

            if (RetainScale && WidthScale != HeightScale)
                HeightScale = WidthScale;

            //TODO
        }
    }
}
