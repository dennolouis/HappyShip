// <copyright file="Leaderboards.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to leaderboards registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Leaderboards
    {
        private static readonly UnifiedLeaderboard s_lvl1 = new UnifiedLeaderboard("lvl1",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl1"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl1"
#endif
            );

        public static UnifiedLeaderboard lvl1
        {
            get { return s_lvl1; }
        }

        private static readonly UnifiedLeaderboard s_lvl2 = new UnifiedLeaderboard("lvl2",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl2"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl2"
#endif
            );

        public static UnifiedLeaderboard lvl2
        {
            get { return s_lvl2; }
        }

        private static readonly UnifiedLeaderboard s_lvl3 = new UnifiedLeaderboard("lvl3",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl3"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl3"
#endif
            );

        public static UnifiedLeaderboard lvl3
        {
            get { return s_lvl3; }
        }

        private static readonly UnifiedLeaderboard s_lvl4 = new UnifiedLeaderboard("lvl4",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl4"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl4"
#endif
            );

        public static UnifiedLeaderboard lvl4
        {
            get { return s_lvl4; }
        }

        private static readonly UnifiedLeaderboard s_lvl5 = new UnifiedLeaderboard("lvl5",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl5"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl5"
#endif
            );

        public static UnifiedLeaderboard lvl5
        {
            get { return s_lvl5; }
        }

        private static readonly UnifiedLeaderboard s_lvl6 = new UnifiedLeaderboard("lvl6",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl6"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl6"
#endif
            );

        public static UnifiedLeaderboard lvl6
        {
            get { return s_lvl6; }
        }

        private static readonly UnifiedLeaderboard s_lvl7 = new UnifiedLeaderboard("lvl7",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl7"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl7"
#endif
            );

        public static UnifiedLeaderboard lvl7
        {
            get { return s_lvl7; }
        }

        private static readonly UnifiedLeaderboard s_lvl8 = new UnifiedLeaderboard("lvl8",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl8"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl8"
#endif
            );

        public static UnifiedLeaderboard lvl8
        {
            get { return s_lvl8; }
        }

        private static readonly UnifiedLeaderboard s_lvl9 = new UnifiedLeaderboard("lvl9",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "lvl9"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "lvl9"
#endif
            );

        public static UnifiedLeaderboard lvl9
        {
            get { return s_lvl9; }
        }

        public static string GetPlatformID(string internalId)
        {
            return s_leaderboardDictionary.ContainsKey(internalId)
                ? s_leaderboardDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedLeaderboard> s_leaderboardDictionary = new Dictionary<string, UnifiedLeaderboard>
        {
            { "lvl1", s_lvl1 },
            { "lvl2", s_lvl2 },
            { "lvl3", s_lvl3 },
            { "lvl4", s_lvl4 },
            { "lvl5", s_lvl5 },
            { "lvl6", s_lvl6 },
            { "lvl7", s_lvl7 },
            { "lvl8", s_lvl8 },
            { "lvl9", s_lvl9 }
        };
    }
}
