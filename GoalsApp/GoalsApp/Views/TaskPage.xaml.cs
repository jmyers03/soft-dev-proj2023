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

        task.GoalId = selectedGoal.Key;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}