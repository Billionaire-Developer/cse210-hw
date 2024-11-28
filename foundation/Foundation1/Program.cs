using System;
using System.Collections.Generic;

public class Comment

{
    public string Name { get; set; }
    public string Text { get; set; }


    public Comment(string name, string text)

    {
        Name = name;
        Text = text;
    }
}

public class Video

{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)

    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Program

{
    static void Main(string[] args)
    
    {
        // Create videos and comments
        Video video1 = new Video("Video 1", "Author 1", 360);
        video1.Comments.Add(new Comment("John", "Great video!"));
        video1.Comments.Add(new Comment("Jane", "I agree!"));

        Video video2 = new Video("Video 2", "Author 2", 540);
        video2.Comments.Add(new Comment("Bob", "Nice work!"));
        video2.Comments.Add(new Comment("Alice", "Thanks!"));

        // Add videos to a list
        List<Video> videos = new List<Video> { video1, video2 };

        // Display video information and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"Comment by {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}