public class Starter
{
    public static void Run()
    {
        MyList<string> myList = new MyList<string>();
        myList.Add("Eva");
        myList.Add("Dark");
        myList.Add("Helen");

        myList.AddRange(new string[] { "Tanya", "Eve", "Frank" });

        myList.Remove("Eve");
        myList.RemoveAt(0);

        myList.Sort();

        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }
    }
}