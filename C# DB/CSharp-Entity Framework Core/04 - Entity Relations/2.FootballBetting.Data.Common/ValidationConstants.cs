namespace P02_FootballBetting.Data.Common
{
    public static class ValidationConstants
    {
        // Team
        public const int MAX_TEAM_NAME_LENGTH = 100;
        public const int MAX_LOGO_URL_LENGTH = 2048;
        public const int MAX_INITIALS_LENGTH = 5;

        // Color
        public const int MAX_COLOR_NAME_LENGTH = 30;

        // Town
        public const int MAX_TOWN_NAME_LENGTH = 85;

        // Country
        public const int MAX_COUNTRY_NAME_LENGTH = 56;

        // Player
        public const int MAX_PLAYER_NAME_LENGTH = 50;

        // Position
        public const int MAX_POSITION_NAME_LENGTH = 30;

        // Game
        public const int MAX_GAME_RESULT_LENGTH = 7;

        // User
        public const int MAX_USER_USERNAME_LENGTH = 36;
        public const int MAX_USER_PASSWORD_LENGTH = 256;
        public const int MAX_USER_EMAIL_LENGTH = 256;
        public const int MAX_USER_NAME_LENGTH = 100;
    }
}
