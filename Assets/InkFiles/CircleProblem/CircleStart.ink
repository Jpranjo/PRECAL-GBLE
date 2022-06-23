INCLUDE ../Globals.ink

{ problem1_state == "NoInteract":-> start | -> midcheck}

=== start ===
What’s wrong?#speaker:MC #portrait:MC
You see, while I was transporting my goods, the wheel of my precious cart broke! #speaker:Merchant #portrait:Merchant
Now, I can easily get a new one from the repairman down the road. 

However, the repairman requires an important piece of information before he is able to begin creating a new wheel.
What does he want to know? #speaker:MC #portrait:MC

Well, he needs to know the standard equation of the wheel, given that the arc of the wheel passes through \
A(-7,0), B(1, 4) and C(7, 2). #speaker:Merchant #portrait:Merchant
I see, I will try to help you. #speaker:MC #portrait:MC 


-> END

=== midcheck ===
{ problem1_state == "Solved":-> solved | ->ask}

=== ask ===
    Are you gonna help me?
    + [Yes]
        ->assignVar("YES")
    + [No]
        ->assignVar("NO")


=== assignVar(answer) ===
{answer == "YES": ->thank | answer == "NO": ->oh}


=== thank ===
Thankyou!
-> END

=== oh ===
Oh okay. Maybe later then...#speaker:Merchant #portrait:Merchant
->END

=== solved ===
Thank you for your assistance! Now I can transport goods again. #speaker:Merchant #portrait:Merchant
You’re welcome! #speaker:MC #portrait:MC 

->END   