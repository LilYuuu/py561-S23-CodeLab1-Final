# Final Project

For the final, I used my midterm project as a starting point. As I briefly mentioned during midterm, I wish to create a storytelling experience/narrative through the game.
I utilized the paper plane as a thread that goes through the story of the main character, El. The plane here in the game is a representation of multiple things - childhood memories, a flight that brought lovers together, or a letter written on paper that was folded into a paper plane. But in general, it is about love. As players fly the plane to the window, they also take a peek at a short clip of El's life about the love she receives.

<img width="865" alt="Screen Shot 2023-05-15 at 9 18 09 AM" src="https://github.com/LilYuuu/py561-S23-CodeLab1-Final/assets/44248733/9088fe48-cdf3-4e25-88b6-24489ca6cd00">

<img width="862" alt="Screen Shot 2023-05-15 at 9 17 26 AM" src="https://github.com/LilYuuu/py561-S23-CodeLab1-Final/assets/44248733/4fbc84b1-9812-4c53-8e26-1c4283d58267">

<img width="864" alt="Screen Shot 2023-05-15 at 9 16 35 AM" src="https://github.com/LilYuuu/py561-S23-CodeLab1-Final/assets/44248733/942b4583-4fde-4461-a337-3f42268c5b1f">


Players can drag and release the plane to make it fly. The distance and angle of the mouse movement, as well as how long the mouse is pressed, determines how far the plane will fly. The goal is to get the plane into the window in order to read the letters to El. Backgrounds in the three levels represent different stages in a day, but also different stages in El's life.

### Techniques used
Singleton, event functions (OnMouseDown, OnMouseDrag, etc.), `Camera.main.WorldToScreenPoint`, `Camera.main.ScreenToWorldPoint`, OOP, data structures (array).

### Further Improvement
* Bugs to be fixed: The stars in Level 3 are always re-instantiated multiple times; the plane jitters on mouse drag.
* Reduce the difficulty of Level 1 (oops)
* Better instructions on how to drag and release the plane
* Bring the narrative to a higher fidelity
