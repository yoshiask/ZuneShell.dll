﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Animations.BaseRotationKeyframe
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Drawing;
using Microsoft.Iris.Render;

namespace Microsoft.Iris.Animations
{
    internal abstract class BaseRotationKeyframe : BaseKeyframe
    {
        private Rotation _valueRotation;

        public BaseRotationKeyframe() => this._valueRotation = Rotation.Default;

        protected override void PopulateAnimationWorker(
          IAnimatable targetObject,
          AnimationProxy animation,
          ref AnimationArgs args)
        {
            Rotation effectiveValue = this.GetEffectiveValue(targetObject, this._valueRotation, ref args);
            animation.AddRotationKeyframe((BaseKeyframe)this, effectiveValue);
        }

        public Rotation Value
        {
            get => this._valueRotation;
            set => this._valueRotation = value;
        }

        public override object ObjectValue => (object)this.Value;

        public virtual Rotation GetEffectiveValue(
          IAnimatable targetObject,
          Rotation baseValueRotation,
          ref AnimationArgs args)
        {
            return baseValueRotation;
        }

        public override void Apply(IAnimatableOwner animationTarget, ref AnimationArgs args)
        {
            Rotation effectiveValue = this.GetEffectiveValue(animationTarget.AnimationTarget, this._valueRotation, ref args);
            this.Apply(animationTarget, effectiveValue);
        }

        public abstract void Apply(IAnimatableOwner animationTarget, Rotation valueRotation);
    }
}
