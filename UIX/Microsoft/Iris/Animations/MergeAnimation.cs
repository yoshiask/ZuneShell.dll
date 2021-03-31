﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Animations.MergeAnimation
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using System.Collections.Generic;

namespace Microsoft.Iris.Animations
{
    internal class MergeAnimation : IAnimationProvider
    {
        private List<IAnimationProvider> _sourcesList;
        private AnimationEventType _type;
        private Animation _cacheAnimation;

        public List<IAnimationProvider> Sources
        {
            get
            {
                if (this._sourcesList == null)
                    this._sourcesList = new List<IAnimationProvider>();
                return this._sourcesList;
            }
            set
            {
                this._sourcesList = value;
                this.ClearCache();
            }
        }

        public AnimationEventType Type
        {
            get => this._type;
            set
            {
                this._type = value;
                this.ClearCache();
            }
        }

        public AnimationTemplate Build(ref AnimationArgs args)
        {
            if (this._cacheAnimation != null)
                return (AnimationTemplate)this._cacheAnimation;
            Animation animation = new Animation();
            animation.Type = this._type;
            animation.DebugID = "Merge(";
            bool flag1 = true;
            foreach (IAnimationProvider sources in this._sourcesList)
            {
                AnimationTemplate anim = sources.Build(ref args);
                if (anim != null)
                {
                    TransformAnimation.DumpAnimation(anim, "Source");
                    string str = anim.DebugID;
                    if (!flag1)
                        str = ", " + str;
                    animation.DebugID += str;
                    flag1 = false;
                    if (animation.Loop != anim.Loop)
                    {
                        bool flag2 = false;
                        if (anim.Loop < 0)
                            flag2 = true;
                        else if (anim.Loop > animation.Loop)
                            flag2 = true;
                        if (flag2)
                            animation.Loop = anim.Loop;
                    }
                    foreach (BaseKeyframe keyframe in anim.Keyframes)
                        animation.AddKeyframe(keyframe);
                }
            }
            animation.DebugID += ")";
            TransformAnimation.DumpAnimation((AnimationTemplate)animation, "Result");
            if (this.CanCache)
                this._cacheAnimation = animation;
            return (AnimationTemplate)animation;
        }

        protected void ClearCache() => this._cacheAnimation = (Animation)null;

        public bool CanCache
        {
            get
            {
                foreach (IAnimationProvider sources in this._sourcesList)
                {
                    if (!sources.CanCache)
                        return false;
                }
                return true;
            }
        }
    }
}