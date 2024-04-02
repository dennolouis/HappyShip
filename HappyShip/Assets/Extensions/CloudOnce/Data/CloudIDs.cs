// <copyright file="CloudIDs.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
#if (UNITY_ANDROID || UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
    using Internal;
    using UnityEngine;
#endif
    /// <summary>
    /// Provides access to achievement- and leaderboard IDs registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class CloudIDs
    {
        /// <summary>
        /// Contains properties that retrieves achievement IDs for the current platform.
        /// </summary>
        public static class AchievementIDs
        {
        }

        /// <summary>
        /// Contains properties that retrieves leaderboard IDs for the current platform.
        /// </summary>
        public static class LeaderboardIDs
        {
            public static string lvl1
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl1";
#elif UNITY_EDITOR
                    return "lvl1";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl2
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl2";
#elif UNITY_EDITOR
                    return "lvl2";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl3
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl3";
#elif UNITY_EDITOR
                    return "lvl3";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl4
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl4";
#elif UNITY_EDITOR
                    return "lvl4";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl5
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl5";
#elif UNITY_EDITOR
                    return "lvl5";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl6
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl6";
#elif UNITY_EDITOR
                    return "lvl6";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl7
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl7";
#elif UNITY_EDITOR
                    return "lvl7";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl8
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl8";
#elif UNITY_EDITOR
                    return "lvl8";
#else
                    return string.Empty;
#endif
                }
            }

            public static string lvl9
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "lvl9";
#elif UNITY_EDITOR
                    return "lvl9";
#else
                    return string.Empty;
#endif
                }
            }
        }
    }
}