namespace _04E.SocialMediaPosts
{
    using System;
    using System.Collections.Generic;

    class SocialMediaPosts
    {
        static void Main()
        {
            var commandLine = Console.ReadLine().Split();

            var dictLikesDislikes = new Dictionary<string, Dictionary<int, int>>();
            var dictComments = new Dictionary<string, Dictionary<string, string>>();

            while (commandLine[0] != "drop")
            {
                GetCommands(commandLine, dictLikesDislikes, dictComments);

                commandLine = Console.ReadLine().Split();
            }

            PrintResult(dictLikesDislikes, dictComments);
        }

        private static void GetCommands(string[] commandLine, Dictionary<string, Dictionary<int, int>> dictLikesDislikes, Dictionary<string, Dictionary<string, string>> dictComments)
        {
            var currentCommand = commandLine[0];
            var currentPost = commandLine[1];

            if (currentCommand == "post")
            {
                if (!dictLikesDislikes.ContainsKey(currentPost))
                {
                    dictLikesDislikes[currentPost] = new Dictionary<int, int>();
                    dictLikesDislikes[currentPost][0] = 0;
                }
            }
            else if (currentCommand == "like")
            {
                foreach (var post in dictLikesDislikes[currentPost])
                {
                    var like = post.Key + 1;
                    var dislike = post.Value;
                    for (int i = 0; i < dictLikesDislikes[currentPost].Count; i++)
                    {
                        dictLikesDislikes[currentPost].Remove(post.Key);
                        dictLikesDislikes[currentPost].Add(like, dislike);
                    }

                    break;
                }
            }
            else if (currentCommand == "dislike")
            {
                foreach (var post in dictLikesDislikes[currentPost])
                {
                    var dislike = post.Value + 1;
                    var key = post.Key;

                    for (int i = 0; i < dictLikesDislikes[currentPost].Count; i++)
                    {
                        dictLikesDislikes[currentPost].Remove(post.Key);
                        dictLikesDislikes[currentPost].Add(key, dislike);
                    }

                    break;
                }
            }
            else
            {
                var commentatorName = commandLine[2];
                string comment = "";
                for (int i = 3; i < commandLine.Length; i++)
                {
                    comment += commandLine[i] + " ";
                }
               

                if (!dictComments.ContainsKey(currentPost))
                {
                    dictComments[currentPost] = new Dictionary<string, string>();
                }

                dictComments[currentPost].Add(commentatorName, comment);
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<int, int>> dictLikesDislikes, Dictionary<string, Dictionary<string, string>> dictComments)
        {
            foreach (var post in dictLikesDislikes)
            {

                Console.Write($"Post: {post.Key} | ");
                foreach (var likeDislike in post.Value)
                {
                    Console.WriteLine($"Likes: {likeDislike.Key} | Dislikes: {likeDislike.Value}");
                }

                Console.WriteLine("Comments:");

                foreach (var comments in dictComments)
                {
                    if (dictComments.ContainsKey(post.Key))
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            foreach (var commentatorAndComment in dictComments[post.Key])
                            {
                                Console.WriteLine($"*  {commentatorAndComment.Key}: {commentatorAndComment.Value}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }

                    break;
                }
            }
        }
    }
}
