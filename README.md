# Unity Game Development OOP Scripting Demo

https://user-images.githubusercontent.com/950298/178923371-77bbb227-7491-4b11-ab7c-d26634da80bc.mp4

## https://play.unity.com/mg/other/webgl-builds-221451

### Overview

My simple project, called Survive the Night, features our Cowboy hero stuck in a floating desert landscape. The sun is about to set, he is starving, and must stock up on food before he runs out of energy for the night. Find your way across the desert in this mini exploration game!

### Controls

Space bar to jump and 'R' key to throw. Arrow keys to control player and 3rd-person camera.

### Comments

This game features many core OOP design pattern implementations. Pickups such as the meats and bones are examples of inheritance. Encapsulation is implemented across every class variable and methods (both along with and independent of inheritance), including abstract, protected, and virtual methods. Polymorphism in the form of method overloading was used throughout the scripts via core Unity MonoBehavior methods for geometry and physics calculations for forces, torque, translation and rotation. Polymorphism in the form of method overriding went along with the aforementioned abstract and virtual methods for encapsulation. Finally, the whole code base practices abstraction by offering easy-to-understand class methods that hide complex logic and requirements in favor of focused, purpose-driven functions.

In addition, the game demonstrates scene management, UI, infinite gameplay, layered triggers and collider interactions (for example, the bone is a prefab that is scripted to be both a projectile and pickup that can dynamically insert and remove rigidbody, trigger collider, and normal collider depending on context), and more.
