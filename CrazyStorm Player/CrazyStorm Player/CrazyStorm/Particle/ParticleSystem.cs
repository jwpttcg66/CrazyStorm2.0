﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CrazyStorm_Player.CrazyStorm
{
    class ParticleSystem : IPlayData
    {
        public string Name { get; set; }
        public IList<ParticleType> CustomTypes { get; private set; }
        public IList<Layer> Layers { get; private set; }
        public ParticleSystem()
        {
            CustomTypes = new List<ParticleType>();
            Layers = new List<Layer>();
        }
        public void LoadPlayData(BinaryReader reader)
        {
            using (BinaryReader particleSystemReader = PlayDataHelper.GetBlockReader(reader))
            {
                Name = PlayDataHelper.ReadString(particleSystemReader);
                //customTypes
                PlayDataHelper.LoadObjectList(CustomTypes, particleSystemReader);
                //layers
                PlayDataHelper.LoadObjectList(Layers, particleSystemReader);
            }
        }
    }
}
