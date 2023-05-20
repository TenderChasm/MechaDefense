using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    public class Animation
    {
        public struct Frame
        {
            public Image Sprite;
            public int BeforeThatFrameSpriteIsValid;

            public Frame(Image sprite, int frame)
            {
                Sprite = sprite;
                BeforeThatFrameSpriteIsValid = frame;
            }
        }

        public int FrameWhenAnimationStarted { get; set; } = 0;
        public  List<Frame> Data { get; set; }
        
        public Animation()
        {
            Data = new List<Frame>();
        }

        public Animation(Animation copyAnimation)
        {
            Data = copyAnimation.Data;
        }

        public Image InterpolateAndGetFrame(int neededFrame,out bool isLastFrame)
        {
            if (FrameWhenAnimationStarted == 0)
                FrameWhenAnimationStarted = neededFrame;

            isLastFrame = false;

            neededFrame -= FrameWhenAnimationStarted;
            int modCount = neededFrame % Data[Data.Count - 1].BeforeThatFrameSpriteIsValid;
            int prevBorder = 0;

            for(int i = 0; i < Data.Count; i++)
            {
                int border = Data[i].BeforeThatFrameSpriteIsValid;
                if (prevBorder <= modCount && modCount < border)
                {
                    if (modCount == Data[Data.Count - 1].BeforeThatFrameSpriteIsValid - 1)
                    {
                        isLastFrame = true;
                        FrameWhenAnimationStarted = 0;
                    }
                    return Data[i].Sprite;
                }
                else
                {
                    prevBorder = border;
                }
            }

            return Data[0].Sprite;
        }
    }
}
