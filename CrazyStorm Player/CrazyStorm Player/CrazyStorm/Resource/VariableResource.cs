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
    class VariableResource : Resource
    {
        public float Value { get; set; }
        public override void LoadPlayData(BinaryReader reader)
        {
            base.LoadPlayData(reader);
            using (BinaryReader variableResourceReader = PlayDataHelper.GetBlockReader(reader))
            {
                Value = variableResourceReader.ReadSingle();
            }
        }
    }
}
