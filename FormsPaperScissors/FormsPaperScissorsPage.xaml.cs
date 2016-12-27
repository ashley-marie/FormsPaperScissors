using System;
//using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsPaperScissors
{
	public partial class FormsPaperScissorsPage : ContentPage
	{
		int score = 0;

		// Create a new dictionary of strings, with string keys.
		// Dictionary<string, string> myDictionary = new Dictionary<string, string> ();



		// Classic C# way of binding for playerChoiceText 
		//public string playerChoiceText
		//{
		//	get {
		//		if (_playerChoiceText == null) {
		//			_playerChoiceText = "You Chose:";
		//		}
		//		return _playerChoiceText;
		//	}
		//	set {
		//		if(_playerChoiceText != value)
		//		{
		//			_playerChoiceText = value;
		//			OnPropertyChanged ("playerChoiceText");
		//		}
		//	}
		//}
		//string _playerChoiceText;




		// using Xamarin.Forms Bindable Properties for playerChoiceText
		public static BindableProperty playerChoiceTextProperty =
			BindableProperty.Create (
				"playerChoiceText", typeof (string), typeof (FormsPaperScissorsPage), "");

		public string playerChoiceText 
		{ 
			get { return (string)GetValue (playerChoiceTextProperty); }
			set { SetValue (playerChoiceTextProperty, value); }
		}

		// using Xamarin.Forms Bindable Properties for computerChoiceText
		public static BindableProperty computerChoiceTextProperty =
			BindableProperty.Create (
				"computerChoiceText", typeof (string), typeof (FormsPaperScissorsPage), "");

		public string computerChoiceText 
		{ 
			get { return (string)GetValue (computerChoiceTextProperty); }
			set { SetValue (computerChoiceTextProperty, value); }
		}

		// using Xamarin.Forms Bindable Properties for scoreText
		public static BindableProperty scoreTextProperty =
			BindableProperty.Create (
				"scoreText", typeof (string), typeof (FormsPaperScissorsPage), "Your Score is: 0");

		public string scoreText 
		{ 
			get { return (string)GetValue (scoreTextProperty); }
			set { SetValue (scoreTextProperty, value); }
		}



		public FormsPaperScissorsPage ()
		{
			InitializeComponent ();
			BindingContext = this;
		}

		void OnRockClicked (object sender, EventArgs args)
		{
			Debug.WriteLine ("You Clicked Rock!");
			choices (0);
		}

		void OnPaperClicked (object sender, EventArgs args)
		{
			Debug.WriteLine ("You Clicked Paper!");
			choices (1);
		}

		void OnScissorsClicked (object sender, EventArgs args)
		{
			Debug.WriteLine ("You Clicked Scissors!");
			choices (2);
		}

		void choices (int playerChoice)
		{

			Random r = new Random ();
			int computerChoice = r.Next (0, 3);


			switch (computerChoice) 
			{
				case 0:
				computerChoiceText = "Rock!";
				break;

				case 1:
				computerChoiceText = "Paper!";
				break;

				case 2:
				computerChoiceText = "Scissors!";
				break;

			default:
				computerChoiceText = "Computer became confused!";
				break;
			}

			switch (playerChoice) 
			{
				case 0:
				playerChoiceText = "Rock!";
				break;

				case 1:
				playerChoiceText = "Paper!";
				break;

				case 2:
				playerChoiceText = "Scissors!";
				break;

				default:
				computerChoiceText = "Computer isn't listening!";
				break;

			}


			if (playerChoice == computerChoice) {
				Debug.WriteLine ("Draw!");
			} else if (playerChoice + 1 % 3 == computerChoice) {
				Debug.WriteLine ("Computer Wins!");
				score -= 1;
			} else {
				Debug.WriteLine ("Player Wins!");
				score += 1;
			}

			scoreText = "Your Score is: " + score;

			// Rock = 0
			// Paper = 1
			// Scissors = 2
		}
	}
}
