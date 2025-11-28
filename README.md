100832558 Arshiya Shahbazpourtazehkand
100755966 Saw Latt
# Road Fighter 
We decided to add a simple button remapping for our game since our logic is pretty simple and in our opinion was the only area that the commnad design pattern would benefit our game. This Remapping could
be useful for people for movement disabilities. By pressing the button R our game input system can switch from right and left arrows to A and D button for movement ot the left and right. 
To achieve this we defined an interface ICommand with a execute method and we then created concrete classes for each action. And then our input handler that has a dictionary mapping for button that gets emptied and refilled
when the rammping button is pressed. 
# Refelection
We knew what had to be done and how to do it and we implemented the required command structure at a decent pace but definitely not in 10 minutes, Which means we might need more practice coding solutions in general
because the issue stems from lack of experinece and taking too much time trying to remember what needs to be done and how we can actually implement them. 
# Controls and gameplay Loop
Left and Right arrows keys to move <-> A and D keys to move 
R to swap between the mapping
Avoid the enemies and score a highscore by surviving! 

![alt text](WASD.png)
