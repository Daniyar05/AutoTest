namespace TestProject1
{

    public class BoardData
    {
        public BoardData()
        {
            //Title = "none";
        }
        public BoardData(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}