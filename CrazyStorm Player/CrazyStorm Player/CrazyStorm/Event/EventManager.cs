﻿/*
 * The MIT License (MIT)
 * Copyright (c) StarX 2016
 */
using System;
using System.Collections.Generic;
using System.Text;
using CrazyStorm.Core;

namespace CrazyStorm_Player.CrazyStorm
{
    class EventManager
    {
        static List<EventExecutor> executorList;
        public static IList<ParticleType> DefaultTypes { get; set; }
        public static IList<ParticleType> CustomTypes { get; set; }
        public static void AddEvent(PropertyContainer propertyContainer, EventInfo eventInfo)
        {
            if (executorList == null)
                executorList = new List<EventExecutor>();

            var executor = new EventExecutor();
            executor.PropertyContainer = propertyContainer;
            executor.PropertyName = eventInfo.resultProperty;
            executor.PropertyType = eventInfo.resultType;
            executor.ChangeMode = eventInfo.changeMode;
            executor.ChangeTime = eventInfo.changeTime;
            propertyContainer.PushProperty(executor.PropertyName);
            var initialValue = new TypeSet();
            var targetValue = eventInfo.resultValue;
            if (eventInfo.isExpressionResult)
            {
                VM.Execute(propertyContainer, eventInfo.resultExpression);
                switch (eventInfo.resultType)
                {
                    case PropertyType.Boolean:
                        targetValue.boolValue = VM.PopBool();
                        initialValue.boolValue = VM.PopBool();
                        break;
                    case PropertyType.Int32:
                        int resultInt = (int)VM.PopFloat();
                        initialValue.intValue = (int)VM.PopFloat();
                        if (eventInfo.changeType == EventKeyword.ChangeTo)
                            targetValue.intValue = resultInt;
                        else if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.intValue = initialValue.intValue + resultInt;
                        else
                            targetValue.intValue = initialValue.intValue - resultInt;

                        break;
                    case PropertyType.Single:
                        float resultFloat = VM.PopFloat();
                        initialValue.floatValue = VM.PopFloat();
                        if (eventInfo.changeType == EventKeyword.ChangeTo)
                            targetValue.floatValue = resultFloat;
                        else if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.floatValue = initialValue.floatValue + resultFloat;
                        else
                            targetValue.floatValue = initialValue.floatValue - resultFloat;

                        break;
                    case PropertyType.Enum:
                        targetValue.enumValue = VM.PopEnum();
                        initialValue.enumValue = VM.PopEnum();
                        break;
                    case PropertyType.Vector2:
                        Vector2 resultVector2 = VM.PopVector2();
                        initialValue.vector2Value = VM.PopVector2();
                        if (eventInfo.changeType == EventKeyword.ChangeTo)
                            targetValue.vector2Value = resultVector2;
                        else if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.vector2Value = initialValue.vector2Value + resultVector2;
                        else
                            targetValue.vector2Value = initialValue.vector2Value - resultVector2;

                        break;
                    case PropertyType.RGB:
                        RGB resultRGB = VM.PopRGB();
                        initialValue.rgbValue = VM.PopRGB();
                        if (eventInfo.changeType == EventKeyword.ChangeTo)
                            targetValue.rgbValue = resultRGB;
                        else if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.rgbValue = initialValue.rgbValue + resultRGB;
                        else
                            targetValue.rgbValue = initialValue.rgbValue - resultRGB;

                        break;
                    case PropertyType.String:
                        targetValue.stringValue = VM.PopString();
                        initialValue.stringValue = VM.PopString();
                        break;
                }
            }
            else
            {
                switch (eventInfo.resultType)
                {
                    case PropertyType.Boolean:
                        initialValue.boolValue = VM.PopBool();
                        break;
                    case PropertyType.Int32:
                        initialValue.intValue = VM.PopInt();
                        if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.intValue = initialValue.intValue + targetValue.intValue;
                        else if (eventInfo.changeType == EventKeyword.Decrease)
                            targetValue.intValue = initialValue.intValue - targetValue.intValue;

                        break;
                    case PropertyType.Single:
                        initialValue.floatValue = VM.PopFloat();
                        if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.floatValue = initialValue.floatValue + targetValue.floatValue;
                        else if (eventInfo.changeType == EventKeyword.Decrease)
                            targetValue.floatValue = initialValue.floatValue - targetValue.floatValue;

                        break;
                    case PropertyType.Enum:
                        initialValue.enumValue = VM.PopEnum();
                        break;
                    case PropertyType.Vector2:
                        initialValue.vector2Value = VM.PopVector2();
                        if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.vector2Value = initialValue.vector2Value + targetValue.vector2Value;
                        else if (eventInfo.changeType == EventKeyword.Decrease)
                            targetValue.vector2Value = initialValue.vector2Value - targetValue.vector2Value;

                        break;
                    case PropertyType.RGB:
                        initialValue.rgbValue = VM.PopRGB();
                        if (eventInfo.changeType == EventKeyword.Increase)
                            targetValue.rgbValue = initialValue.rgbValue + targetValue.rgbValue;
                        else if (eventInfo.changeType == EventKeyword.Decrease)
                            targetValue.rgbValue = initialValue.rgbValue - targetValue.rgbValue;

                        break;
                    case PropertyType.String:
                        initialValue.stringValue = VM.PopString();
                        break;
                }
            }
            executor.InitialValue = initialValue;
            executor.TargetValue = targetValue;
            if (executor.ChangeMode == EventKeyword.Instant)
                executor.Update();
            else
                executorList.Add(executor);
        }
        public static bool ExecuteSpecialEvent(PropertyContainer propertyContainer, string eventName, string[] arguments, 
            VMInstruction[] argumentExpression)
        {
            switch (eventName)
            {
                case "EmitParticle":
                    (propertyContainer as Emitter).EmitParticle();
                    break;
                case "PlaySound":
                    //TODO
                    break;
                case "Loop":
                    VM.Execute(propertyContainer, argumentExpression);
                    if (!VM.PopBool())
                        return true;

                    break;
                case "ChangeType":
                    int typeId = int.Parse(arguments[0]) + int.Parse(arguments[1]);
                    if (typeId >= ParticleType.DefaultTypeIndex)
                    {
                        if (propertyContainer is Emitter)
                            (propertyContainer as Emitter).Template.Type = DefaultTypes[typeId - ParticleType.DefaultTypeIndex];
                        else if (propertyContainer is ParticleBase)
                            (propertyContainer as ParticleBase).Type = DefaultTypes[typeId - ParticleType.DefaultTypeIndex];
                    }
                    else
                    {
                        if (propertyContainer is Emitter)
                            (propertyContainer as Emitter).Template.Type = CustomTypes[typeId];
                        else if (propertyContainer is ParticleBase)
                            (propertyContainer as ParticleBase).Type = CustomTypes[typeId];
                    }
                    break;
            }
            return false;
        }
        public static void Update()
        {
            if (executorList == null)
                return;

            for (int i = 0; i < executorList.Count;++i)
            {
                executorList[i].Update();
                if (executorList[i].Finished)
                {
                    executorList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
