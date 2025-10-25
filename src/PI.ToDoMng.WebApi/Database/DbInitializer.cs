namespace PI.ToDoMng.WebApi.Database;

public static class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        var toDoItem = new ToDoItem(0, "Item 1", "Description", false, DateTime.Now);
        var toDoItem2 = new ToDoItem(0, "Item 2", "Description", false, DateTime.Now);
        var toDoItem3 = new ToDoItem(0, "Item 3", "Description", false, DateTime.Now);
        
        context.ToDoItems.Add(toDoItem);
        context.ToDoItems.Add(toDoItem2);
        context.ToDoItems.Add(toDoItem3);

        // Save changes
        context.SaveChanges();
    }
}