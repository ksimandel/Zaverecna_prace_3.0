using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Zaverecna_prace_3._0;

namespace Zaverecna_prace_3._0
{
    public partial class MainWindow : Window
    {
        private Game game = new();

        public MainWindow()
        {
            InitializeComponent();

            CreateScenes();

            game.Start();

            RenderScene();
        }
        private void SceneCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(SceneCanvas);

            Canvas.SetLeft(HoverText, pos.X + 15);
            Canvas.SetTop(HoverText, pos.Y + 10);
        }

        private List<DialogueLine> currentDialogue;
        private int dialogueIndex;
        private void StartDialogue(List<DialogueLine> dialogue)
        {
            currentDialogue = dialogue;
            dialogueIndex = 0;

            DialogueBox.Visibility = Visibility.Visible;

            ShowDialogueLine();
        }
        private void ShowDialogueLine()
        {
            if (currentDialogue == null || dialogueIndex >= currentDialogue.Count)
            {
                EndDialogue();
                return;
            }

            var line = currentDialogue[dialogueIndex];

            SpeakerText.Text = line.Speaker;
            DialogueText.Text = line.Text;
        }
        private void NextDialogue()
        {
            dialogueIndex++;
            ShowDialogueLine();
        }
        private void EndDialogue()
        {
            DialogueBox.Visibility = Visibility.Collapsed;
            currentDialogue = null;

            var nextScene = game.CurrentScene.NextSceneAfterDialogue;

            if (!string.IsNullOrEmpty(nextScene))
            {
                game.ChangeScene(nextScene);
                RenderScene();
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentDialogue != null)
            {
                NextDialogue();
            }
        }

        private void CreateScenes()
        {
            // MENU
            var menu = new Scene
            {
                Id = "menu",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/menu_bg.png")),

                NextSceneAfterDialogue = null
            };

            menu.Buttons.Add(new SceneButton
            {
                Content = "NEW GAME",
                HoverText = "Start New Game?",
                X = 520,
                Y = 400,
                Width = 800,
                Height = 400,
                TargetSceneId = "level1",
                ButtonImage = "Images/start_game.png"

            });




            // THE LOBBY SCENE
            var level1 = new Scene
            {
                Id = "level1",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/Level_0_The_Lobby.png")),
                    
                NextSceneAfterDialogue = null
            };

            level1.Dialogue.Add(new DialogueLine
            {
                Speaker = "You",
                Text = "Where am I?!..."
            });


            level1.Buttons.Add(new SceneButton
            {
                HoverText = "Go forward...",
                X = 700,
                Y = 400,
                Width = 100,
                Height = 200,
                TargetSceneId = "level2",
                RequiredItem = "Flashlight"

            });

            level1.Buttons.Add(new SceneButton
            {
                HoverText = "Go right...",
                X = 1700,
                Y = 400,
                Width = 100,
                Height = 200,
                TargetSceneId = "flashlight_scene",
                

            });

            level1.Buttons.Add(new SceneButton
            {
                HoverText = "Inspect safe...",
                X = 850,
                Y = 700,
                Width = 200,
                Height = 200,
                TargetSceneId = "safe_scene",


            });



            //FLASHLIGHT_PICKUP_SCENE
            var flashlight_scene = new Scene
            {
                Id = "flashlight_scene",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/flashlight_location.jpg")),

                NextSceneAfterDialogue = null
            };
            
            flashlight_scene.Buttons.Add(new SceneButton
            {
                HoverText = "Pick up a Flashlight...",
                X = 420,
                Y = 750,
                Width = 60,
                Height = 40,
                ItemToGive = "Flashlight",
                ButtonImage = "Images/flashlight.png"
            });



            flashlight_scene.Buttons.Add(new SceneButton
            {
                HoverText = "Go back...",
                X = 100,
                Y = 100,
                Width = 200,
                Height = 100,
                TargetSceneId = "level1"
            });

            // POOLROOMS SCENE
            var level2 = new Scene
            {
                Id = "level2",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/60ae0aefdfbdb915ec71b474ca68b4e953a622b8_2_1024x562.jpeg")),
                
                NextSceneAfterDialogue = null // no auto switch
                
            };

            level2.Dialogue.Add(new DialogueLine
            {
                Speaker = "You",
                Text = "Where the hell am I now?"
            });

            level2.Dialogue.Add(new DialogueLine
            {
                Speaker = "You",
                Text = "Also..."
            });

            level2.Dialogue.Add(new DialogueLine
            {
                Speaker = "You",
                Text = "Why does it here look like a waterpark catacombs?"
            });

            level2.Dialogue.Add(new DialogueLine
            {
                Speaker = "You",
                Text = "Oh well... which way should i go?..."
            });

            level2.Buttons.Add(new SceneButton
            {
                HoverText = "Go back...",
                X = 100,
                Y = 100,
                Width = 200,
                Height = 100,
                TargetSceneId = "level1"
            });

            level2.Buttons.Add(new SceneButton
            {
                HoverText = "Go right...",
                X = 1100,
                Y = 250,
                Width = 300,
                Height = 400,
                TargetSceneId = "poolrooms2"
            });

            // POOLROOMS SCENE
            var poolrooms_numbers_scene = new Scene
            {
                Id = "poolrooms2",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/poolrooms_numbers.png")),

                NextSceneAfterDialogue = null // no auto switch

            };

            poolrooms_numbers_scene.Dialogue.Add(new DialogueLine
            {
                Speaker = "You",
                Text = "What is this?"
            });

            poolrooms_numbers_scene.Buttons.Add(new SceneButton
            {
                HoverText = "Go back...",
                X = 100,
                Y = 100,
                Width = 200,
                Height = 100,
                TargetSceneId = "level2"
            });

            poolrooms_numbers_scene.Buttons.Add(new SceneButton
            {
                HoverText = "Pick up a letter...",
                X = 1500,
                Y = 900,
                Width = 30,
                Height = 30,
                ItemToGive = "Letter, that says: Look at the plants...",
                ButtonImage = "Images/letter.png"
            });

            var safe_scene = new Scene
            {
                Id = "safe_scene",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/safe_scene.png")),

                NextSceneAfterDialogue = null
            };

            safe_scene.Buttons.Add(new SceneButton
            {
                HoverText = "Go back...",
                X = 100,
                Y = 100,
                Width = 200,
                Height = 100,
                TargetSceneId = "level1"
            });

            safe_scene.Buttons.Add(new SceneButton
            {
                Content = "ENTER CODE",
                HoverText = "Try to open the lock...",
                X = 860,   // Positions the button near the middle-bottom of the safe panel
                Y = 800,
                Width = 200,
                Height = 50,
                TargetSceneId = "" // We leave this blank because we handle the transition via code manually below
            });

            var tobecontinued = new Scene
            {
                Id = "tobecontinued",
                BackgroundImage = new BitmapImage(
                    new Uri("pack://application:,,,/Images/tobecontinued.png")),

                NextSceneAfterDialogue = null
            };


            // Přidává scény!!!
            game.Scenes.Add(menu.Id, menu);
            game.Scenes.Add(level1.Id, level1);
            game.Scenes.Add(level2.Id, level2);
            game.Scenes.Add(flashlight_scene.Id, flashlight_scene);
            game.Scenes.Add(poolrooms_numbers_scene.Id, poolrooms_numbers_scene);
            game.Scenes.Add(safe_scene.Id, safe_scene);
            game.Scenes.Add(tobecontinued.Id, tobecontinued);

            // ZAČÍNAJÍCÍ SCÉNA
            game.StartingSceneId = "menu";
        }

        private void RenderScene()
        {
            var scene = game.CurrentScene;

            SceneBackground.Source = scene.BackgroundImage;

            SceneCanvas.Children.Clear();

            SceneCanvas.Children.Add(HoverText);


            foreach (var sceneButton in scene.Buttons)
            {
                Button button = new Button
                {
                    Content = sceneButton.Content,
                    Width = sceneButton.Width,
                    Height = sceneButton.Height,
                    Background = new SolidColorBrush(Color.FromArgb(60, 255, 255, 255)),
                    BorderThickness = new Thickness(0)
                };

                if (!string.IsNullOrEmpty(sceneButton.ButtonImage))
                {
                    
                    button.Background = Brushes.Transparent;

                    
                    Image btnImg = new Image
                    {
                        Source = new BitmapImage(new Uri($"pack://application:,,,/{sceneButton.ButtonImage}")),
                        Stretch = Stretch.Uniform
                    };

                    
                    button.Content = btnImg;
                }
                else
                {
                    
                    button.Background = new SolidColorBrush(Color.FromArgb(60, 255, 255, 255));
                }

                Canvas.SetLeft(button, sceneButton.X);
                Canvas.SetTop(button, sceneButton.Y);


                button.Click += (s, e) =>
                {
                    if (sceneButton.Content == "ENTER CODE")
                    {

                        string inputCode = Microsoft.VisualBasic.Interaction.InputBox(
                            "Enter the 4-digit safe combination:",
                            "Safe Lock",
                            "");

                        if (inputCode == "3829")
                        {
                            MessageBox.Show("Click! The safe clicks open.");

                            SceneCanvas.Children.Remove(button);
                            scene.Buttons.Remove(sceneButton);


                            TransitionToScene("tobecontinued");
                        }
                        else if (!string.IsNullOrEmpty(inputCode))
                        {

                            List<DialogueLine> wrongCodeDialogue = new List<DialogueLine>
            {
                new DialogueLine { Speaker = "You", Text = "Damn, that didn't work. The dial won't budge." }
            };
                            StartDialogue(wrongCodeDialogue);
                        }
                        return;
                    }
                    if (!string.IsNullOrEmpty(sceneButton.ItemToGive))
                    {
                        
                        game.Inventory.Add(sceneButton.ItemToGive);

                        RefreshInventoryUI();

                        MessageBox.Show($"You picked up: {sceneButton.ItemToGive}!");

                        
                        SceneCanvas.Children.Remove(button);

                        
                        scene.Buttons.Remove(sceneButton);
                        return;
                    }

                    if (game.HasItem(sceneButton.RequiredItem))
                    {
                        TransitionToScene(sceneButton.TargetSceneId);
                    }
                    else
                    {
                        List<DialogueLine> lockoutDialogue = new List<DialogueLine>
                            {
                                new DialogueLine
                                {
                                    Speaker = "System",
                                    Text = $"This way is locked. You need a [{sceneButton.RequiredItem}] to proceed."
                                }
                            };

                        
                        StartDialogue(lockoutDialogue); 
                    }
                };

                button.MouseEnter += (s, e) =>
                {
                    HoverText.Text = sceneButton.HoverText;
                    HoverText.Visibility = Visibility.Visible;
                };

                button.MouseLeave += (s, e) =>
                {
                    HoverText.Visibility = Visibility.Collapsed;
                };

                SceneCanvas.Children.Add(button);
            }

           
            if (scene.Dialogue != null && scene.Dialogue.Count > 0 && !scene.IsDialogueRead)
            {
                scene.IsDialogueRead = true;
                StartDialogue(scene.Dialogue);
            }
            else
            {
                DialogueBox.Visibility = Visibility.Collapsed;
            }
        }

        private void RefreshInventoryUI()
        {
            
            InventoryDisplay.ItemsSource = null;

            
            var visualItems = new List<Image>();

            foreach (var itemName in game.Inventory)
            {
                
                string imagePath = itemName switch
                {
                    "Flashlight" => "Images/flashlight.png",
                    "Letter, that says: Look at the plants..." => "Images/letter.png",
                    "Crowbar" => "Images/crowbar_icon.png",
                    _ => "Images/default_item_icon.png" 
                };

                Image img = new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/{imagePath}")),
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5),
                    ToolTip = itemName 
                };

                visualItems.Add(img);
            }

            
            InventoryDisplay.ItemsSource = visualItems;
        }


        private void TransitionToScene(string targetSceneId)
        {

            DoubleAnimation fadeOut = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.3)
            };


            fadeOut.Completed += (s, e) =>
            {

                game.ChangeScene(targetSceneId);
                RenderScene();


                DoubleAnimation fadeIn = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(0.3)
                };

                MainGrid.BeginAnimation(Grid.OpacityProperty, fadeIn);
            };


            MainGrid.BeginAnimation(Grid.OpacityProperty, fadeOut);
        }
    }
}
