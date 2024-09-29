# Zombie AI
A few years ago, I developed the AI for a VR game featuring various zombie enemies that could perform various actions and attacks on the player. My goal was to create a robust AI system that allowed for future expansion without breaking existing functionality. The design I implemented shares similarities with both behavior trees and finite state machines. However, since this project was completed quite some time ago, the code does not follow the majority of my current coding practices and techniques, so I wouldn't classify it as my best work. Due to this, I plan to reflect on my older work at the end of this.

# AI System
The primary components of my AI system are [States](State.cs), [Actions](Action.cs), and [Transitions](Transition.cs), with states and actions implemented as ScriptableObjects that can be defined within the Unity Editor. A [State](State.cs) contains an array of [Actions](Action.cs) and [Transitions](Transition.cs) that are processed each frame.

### Actions
[Actions](Action.cs) define the various tasks an AI agent can perform, such as moving towards a target, switching animations, playing sounds, or dealing damage. The goal in programming these Actions was to ensure flexibility, enabling designers to combine multiple actions to create complex behaviors.

![image](https://github.com/user-attachments/assets/b555a84c-ef5c-4e72-bebf-e982947c552e)
![image](https://github.com/user-attachments/assets/edcd1165-0710-492f-9765-8ef296ea4bf5)


### Transitions
[Transitions](Transition.cs) manage how [States](State.cs) switch from one to another. They utilise another ScriptableObject called a [Condition](Condition.cs), which specifies the criteria for the State to check before transitioning to a new one. I implemented several conditions, such as checking if a target is dead or if the AI agent has reached its destination.

![image](https://github.com/user-attachments/assets/c71f0265-0180-4094-94f9-11dff803c153)
![image](https://github.com/user-attachments/assets/4ae7ef5b-8a73-41bc-bd63-51c2167d0a3f)


### States & The Brain
Lastly, a [State](State.cs) defines the current state an agent can be in, such as attacking the player or dying. Utilising [States](State.cs), [Actions](Action.cs), and [Transitions](Transition.cs) allows us to define various complex behaviors for an agent, all within the Unity Editor.

which is used to define the current state an agent can be in, such as attacking the player or dying. Utilising [States](State.cs), [Actions](Action.cs), and [Transitions](Transition.cs) allows us to define various complex behaviour for an agent to perform, all within the Unity Editor.

![image](https://github.com/user-attachments/assets/735007df-1556-46bd-9c0e-d36cc2b91632)

Each State an agent can be in is managed by the [Brain](Brain.cs), a component that updates the state of each agent, per frame.

![image](https://github.com/user-attachments/assets/271606ff-8b0d-44c7-a7fa-a133bafe8984)

### Reflection on Older Work
Looking back on this system, I recognise that it is far from perfect, but it does accomplish my primary goal of creating a robust and designer-friendly system. My main concern with the current implementation is how I've handled the [States](State.cs), as the chain of actions an AI agent takes is defined through the state rather than managed by the [Brain](Brain.cs) itself. This approach worked well with the limited number of agents in the game, but as we'd expandm introducing new zombies with unique behaviors, it could lead to complications due to agents sharing the same states.

For example, with the "Attack Player" state, the transitions for checking if an entity is dead and whether the agent has reached its destination are shared among all zombies using this state. However, what if a zombie needed to explode upon reaching its destination? While it’s possible to create a new "Attack Player" state for that functionality, having multiple states with similar goals can quickly become confusing in larger projects.

![image](https://github.com/user-attachments/assets/45ed153a-384a-4613-8789-a79123d7d905)

Instead, I would define agent states and transitions within the [Brain](Brain.cs) itself, which is already unique to each zombie. This way, each zombie can maintain its own set of states and transitions without requiring designers to create numerous similar state objects.
