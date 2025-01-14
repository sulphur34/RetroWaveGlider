using System.Collections.Generic;
using ColorSystem;
using Glider.ModuleSystem;
using UnityEngine;

namespace Glider
{
    public class GliderFactory
    {
        private ColorAnimator _colorAnimator;
        private GliderConfig[] _gliderConfigs;
        private ModuleConfig[] _moduleConfigs;

        public GliderFactory(
            Dictionary<string,GliderConfig> gliderConfigs, 
            ModuleConfig[] moduleConfigs, 
            ColorAnimator colorAnimator)
        {
            _colorAnimator = colorAnimator;
        }
    }
}