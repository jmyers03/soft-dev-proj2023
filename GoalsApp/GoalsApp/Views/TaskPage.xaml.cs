using GoalsApp.ViewModels;
using GoalsApp.Models;

namespace GoalsApp.Views;

public partial class TaskPage : ContentPage
{
	public TaskPage()
	{
		InitializeComponent();

        //Set the binding context to the TaskPageViewModel 
        BindingContext = new TaskPageViewModel();
    }

    // May need to viewModel so the View does not know about the Model (follows MVVM)
    private void AddDefaultTask(object sender, EventArgs e)
    {
        var defaultTask = new MyTask { Id = "0", Title = "Default Task", Description = "Default Description" };

        // Add the new task to the beginning of the list
        // Converts BindingContext current datatype to TaskPageViewModel and inserting the new task in first position of list
        ((TaskPageViewModel)BindingContext).currentTasks.Insert(0, defaultTask);
    }

    private void CurrentCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkbox = (CheckBox)sender;
        var task = (MyTask)checkbox.BindingContext;
        task.Completed = true;
        if (task.Completed)
        {
            // Fade out the control
            checkbox.FadeTo(0, 1000);
            // Move the task to the CompletedTasks list
            ((TaskPageViewModel)BindingContext).MoveToCompleted(task);
        }
    }
    private void DeleteTask(object sender, EventArgs e)
    {
        // trashcan is set to the object that was clicked
        var trashcan = (ImageButton)sender;
        //fade animation of item
        trashcan.FadeTo(0, 1000);
        // casting bindingcontext of imagebutton to MyTask and calling it task
        var task = (MyTask)trashcan.BindingContext;
        ((TaskPageViewModel)BindingContext).currentTasks.Remove(task);
    }

    private void MoveBack_Clicked(object sender, EventArgs e)
    {
        // trashcan is set to the object that was clicked
        var moveBack = (ImageButton)sender;
        // casting bindingcontext of imagebutton to MyTask and calling it task
        var task = (MyTask)moveBack.BindingContext;
        ((TaskPageViewModel)BindingContext).MoveToCurrent(task);
    }
}