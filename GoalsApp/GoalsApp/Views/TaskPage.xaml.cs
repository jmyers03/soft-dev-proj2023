using GoalsApp.ViewModels;
using GoalsApp.Models;
using Microsoft.Maui.Controls;
using Firebase.Database;
using Firebase.Database.Query;

namespace GoalsApp.Views;

public partial class TaskPage : ContentPage
{
    TaskPageViewModel viewModel = new TaskPageViewModel();
	public TaskPage()
	{
		InitializeComponent();

        //Method defined right below 
        InitializeViewModel();
    }

    private async void InitializeViewModel()
    {
        //sets the current Tasks list equal to the list 
        await viewModel.GetUserTasks();
        BindingContext = viewModel;
    }

    // May need to viewModel so the View does not know about the Model (follows MVVM)
    // - will move them and will have to push and pull data to the database in the methods 
    private void AddDefaultTask(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            // Access the BindingContext directly, assuming it is a MyTask
            viewModel.AddDefaultTask(button.BindingContext as MyTask);
        }
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

    private void GoalPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedGoal = (Goal)picker.SelectedItem;
        var parent = (StackLayout)picker.Parent;
        var task = (MyTask)parent.BindingContext;

        task.GoalKey = selectedGoal.Key;

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var task = (MyTask)button.BindingContext;

        // Call the SaveTask method from the view model
        await viewModel.SaveTask(task);
    }
}