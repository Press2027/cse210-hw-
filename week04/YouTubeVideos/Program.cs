using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to remove stuck bolt", "CookingWithSam", 420);
        Video video2 = new Video("Top 10 excel Tips", "DevMaster", 610);
        Video video3 = new Video("Life in Paris ", "TravelGuru", 900);

        // Add comments to video 1
        video1.AddComment(new Comment("Preston", "This was super helpful!"));
        video1.AddComment(new Comment("John", "I tried this and it came out perfect."));
        video1.AddComment(new Comment("Marie", "Great."));

        // Add comments to video 2
        video2.AddComment(new Comment("James", "Tip #3 changed my life."));
        video2.AddComment(new Comment("Dorah", "Very clear and easy to follow."));
        video2.AddComment(new Comment("Chris", "Please adjust your voice!"));

        // Add comments to video 3
        video3.AddComment(new Comment("Nina", "Paris looks amazing."));
        video3.AddComment(new Comment("Oscar", "Adding this to my travel list!"));
        video3.AddComment(new Comment("Tom", "Am viting there next week!"));

        // Put videos in a list
        List<Video> videos = new List<Video>() { video1, video2, video3 };

        // Display video info
        foreach (Video v in videos)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {v.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"  - {c.CommenterName}: {c.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
