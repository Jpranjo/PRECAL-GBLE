INCLUDE ../Globals.ink

{ problem3_state == "NoInteract":-> start | -> midcheck}

=== start ===
EAT
How is my boss expecting me to do this alone? #speaker:Soldier #portrait:soldier_2
Do you need some help there?#speaker:MC #portrait:MC 
I don't have an idea on how to create the perfect wings for this airplane.#speaker:Soldier #portrait:soldier_2
Are there some conditions you need to meet?#speaker:MC #portrait:MC 
My friend told me to determine the equation of the wings to be generated for the new airplane is about 6 units long and half a unit wide. Do you have any idea how to do this? #speaker:Soldier #portrait:soldier_2
Let me see what I can do,,, #speaker:MC #portrait:MC 


-> END

=== midcheck ===
{ problem3_state == "Solved":-> solved | ->ask}

=== ask ===
This is driving me crazy! Do you have any progress? #speaker:Soldier #portrait:soldier_2
I haven't solved it yet. #speaker:MC #portrait:MC 
->END

=== solved ===
I am really grateful for your assistance! Now I can fly this plane again. #speaker:Soldier #portrait:soldier_2
Enjoy riding your plane! #speaker:MC #portrait:MC 

->END   