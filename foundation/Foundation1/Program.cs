using System;
using System.Collections.Generic;

// Comment class to store information about individual comments
class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }
    public DateTime DatePosted { get; set; }

    // Constructor to initialize comment details
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
        DatePosted = DateTime.Now; // Automatically set to current date/time when the comment is posted
    }

    // Method to return the details of a comment
    public string GetCommentDetails()
    {
        return $"{CommenterName}: {CommentText} (Posted on {DatePosted})";
    }
}

// Video class to store information about a video and manage comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }
    public int Views { get; set; }
    public DateTime UploadDate { get; set; }

    // Constructor to initialize video details
    public Video(string title, string author, int lengthInSeconds, DateTime uploadDate)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        UploadDate = uploadDate;
        Comments = new List<Comment>();
        Views = 0; // Start with zero views
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetCommentCount()
    {
        return Comments.Count;
    }

    // Method to display video details
    public string GetVideoDetails()
    {
        return $"{Title} by {Author}, Length: {LengthInSeconds} seconds, Uploaded on {UploadDate.ToShortDateString()}, Views: {Views}";
    }

    // Method to get comments posted after a certain date (optional functionality)
    public List<Comment> GetCommentsAfter(DateTime date)
    {
        return Comments.FindAll(c => c.DatePosted > date);
    }

    // Method to update the view count (optional functionality)
    public void UpdateViews(int newViewCount)
    {
        Views = newViewCount;
    }

    // Method to remove a comment (optional functionality)
    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create video instances with initial upload date
        Video video1 = new Video("Introduction to C#", "IJABOR ROSUO", 600, new DateTime(2023, 1, 15));
        Video video2 = new Video("Advanced Node.js", "Jane Smith", 1200, new DateTime(2023, 3, 22));
        Video video3 = new Video("Understanding AI", "Sam Lee", 900, new DateTime(2023, 7, 10));

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Loved the explanation."));

        // Add comments to video2
        video2.AddComment(new Comment("Dave", "Awesome content!"));
        video2.AddComment(new Comment("Eve", "Helped a lot, thanks!"));

        // Add comments to video3
        video3.AddComment(new Comment("Frank", "Clear and concise."));
        video3.AddComment(new Comment("Grace", "AI is fascinating!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Video Details: {video.GetVideoDetails()}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.GetCommentDetails()}");
            }
            Console.WriteLine(); // Newline for better readability
        }
    }
}
