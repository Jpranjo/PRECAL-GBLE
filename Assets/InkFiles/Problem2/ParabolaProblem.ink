INCLUDE ../Globals.ink

{ problem2_state == "NoInteract":-> start | -> midcheck}

=== start ===
What happened here? #speaker:MC #portrait:MC 

A magnitude 6.0 earthquake occurred three days ago. I came here to check the situation and it turned out worse than I expected. #speaker:Soldier #portrait:soldier

How do you plan to fix this? #speaker:MC #portrait:MC 

I have been told that I can bring the bridge back to how it was before in one way, but I am not sure how to do it. #speaker:Soldier #portrait:soldier

What do you need to do? #speaker:MC #portrait:MC 

I need to determine the equation for the parabolic shape cables of the bridge that are supported by 25m tall towers, 80m apart, and their lowest point being 5m above the bridge surface. Do you have any idea how to find out the answer to this? #speaker:Soldier #portrait:soldier

I'm not sure, but I might know a way. #speaker:MC #portrait:MC 
-> END

=== midcheck ===
{ problem2_state == "Solved":-> solved | ->ask}

=== ask ===
I really wish the damage wasn't this bad... #speaker:Soldier #portrait:soldier
It will be alright, I will try to solve this. #speaker:MC #portrait:MC 
->END

=== solved ===
Now the people of this city can use the bridge again, thank you for your assistance#speaker:Soldier #portrait:soldier
It is my pleasure to have been of help. #speaker:MC #portrait:MC 

->END   