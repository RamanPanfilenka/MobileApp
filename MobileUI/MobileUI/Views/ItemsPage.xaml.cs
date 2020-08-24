using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileUI.Models;
using MobileUI.Views;
using MobileUI.ViewModels;
using BusinessLogic;
using MovieDb;
using GoogleTable;

namespace MobileUI.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        IActivity _activity = new Activity(new GoogleSheetFilmService(), new MovieDbService());

        public ItemsPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new ItemsViewModel();
            LoadFilms();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void LoadFilms() {
            var films = await _activity.GetSavedFilms();
            var listView = new ListView()
            {
                HasUnevenRows = true,
                ItemsSource = films,
                ItemTemplate = new DataTemplate(GetFilmDataTemplate)
            };
            this.Content = listView;
        }

        private ScrollView GetFilmDataTemplate() {
            var title = CreateLabel("Title");
            var genre = CreateLabel("Genre");
            var runTime = CreateLabel("RunTime");
            var peopleRating = CreateLabel("PeopleRating");
            var yegorRating = CreateLabel("YegorRating");
            var romaRating = CreateLabel("RomaRating");

            var stackLayout = new StackLayout() {
                Padding = new Thickness(0, 5),
                Orientation = StackOrientation.Vertical,
                Children = { title, genre, runTime, peopleRating, yegorRating, romaRating }
            };
            var scrollLayout = new ScrollView() {
                Content = stackLayout,
            };

            return scrollLayout;
        }

        private Label CreateLabel(string bindingProperty) {
            var label = new Label { FontSize = 18 };
            label.SetBinding(Label.TextProperty, bindingProperty);

            return label;
        }
    }
}