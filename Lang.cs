using System.Collections.Generic;

namespace Utils
{
    public class Lang
    {
        public static string Trans(string key)
        {
            return en()[key];
        }

        public static Dictionary<string, string> en()
        {
            return new Dictionary<string, string>()
            {
                {"game_title", "2048"},
                {"moves", "Moves"},
                {"time", "Time"},
                {"high_score", "High Score"},
                {"play", "Play"},
                {"moves_left", "Moves Left"},
                {"score", "Score"},
                {"pause", "Pause"},
                {"stats", "Stats"},
                {"lets_play", "Let\'s Play"},
                {"how_to_play", "How to play"},
                {"leaderboard", "Leaderboard"},
                {"remove_ads", "Remove Ads"},
                {"settings", "Settings"},
                {"exit", "exit"},
                {"your_score_is", "Your score is"},
                {"level_completed", "Level completed!"},
                {"challenge", "Challenge"},
                {"your_friends", "your friends"},
                {"share", "Share"},
                {"with_friends", "With friends"},
                {"next_level", "Next Level"},
                {"tutorial_title", "How to play"},
                {"tutorial_content", "Use your arrow keys to move the tiles. When two tiles with the same number touch, they merge into one!"},
                {"remove_ads_title", "Remove ads title"},
                {"remove_ads_content", "content here"},
            };
        }

        public static Dictionary<string, string> fr()
        {
            return new Dictionary<string, string>()
            {
                {"moves", "Moves"},
                {"time", "Time"},
                {"high_score", "High Score"},
                {"play", "Play"},
                {"moves", "Moves"},
                {"moves", "Moves"},
                {"moves", "Moves"},
            };
        }
    }
}