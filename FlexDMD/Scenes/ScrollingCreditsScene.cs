﻿/* Copyright 2019 Vincent Bousquet

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */

namespace FlexDMD.Scenes
{
    class ScrollingCreditsScene : BackgroundScene
    {
        private readonly Group _container = new Group();
        private readonly float _length;

        public ScrollingCreditsScene(Actor background, string[] text, Font font, AnimationType animateIn, float pauseS, AnimationType animateOut, string id = "") : base(background, animateIn, pauseS, animateOut, id)
        {
            // There is nothing obvious in UltraDMD that gives hint on the timing, so I choosed one.
            _length = 3f + text.Length * 0.4f;
            AddActor(_container);
            var y = 0f;
            foreach (string line in text)
            {
                var label = new Label(font, line);
                label.Y = y;
                y += label.Height;
                _container.AddActor(label);
            }
            _container.Height = y;
        }

        public override void Begin()
        {
            base.Begin();
            _container.Y = Height;
            _tweener.Tween(_container, new { Y = -_container.Height }, _length, 0f);
        }

        public override void Update(float delta)
        {
            base.Update(delta);
            if (_container.Width != Width)
            {
                _container.Width = Width;
                foreach (Actor line in _container.Children)
                {
                    line.X = (Width - line.Width) / 2;
                }
            }
        }
    }
}
