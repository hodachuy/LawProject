using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Constants
{
    public static class CacheKeys
    {
        public const string Domain = "ThisDomain";

        public static class Question
        {
            public const string StartsWith = "Question.";
        }

        public static class Legal
        {
            public const string StartsWith = "Legal.";
        }

        public static class Post
        {
            public const string StartsWith = "Post.";
        }

        public static class Setting
        {
            public const string StartsWith = "Setting.";
        }
    }
}
