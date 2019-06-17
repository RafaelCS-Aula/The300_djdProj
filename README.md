# README

### Check the branch `before_refactor` to see how the code was before the refactor happened.
Most stuff was moved and re-utilized, some got cut because it was too awkward or it was gonna get axed anyway.
This includes code that used Animators and animations so that has to be done again.



### TODO:
* Feedback 
* Implement Animations
  * Sprites and class to handle animation logic
* Make AI maybe not retardo (maybe done?)
* Win and lose screens (Game Over screen?) 
* UI work
* **FOLLOWERS, added with new refactor logic** (r -> on it)

### Major changes and how the stuff works
* `Control` classes contain the logic to determine what formation the army is in, the `Army` script has the stats(speed, atk etc) and handles the logic that deals with those properties including taking and dealing damage
  * To make an army just drag a `Control` inheriting script to a gameobject
    * So, `PlayerControl` for the player army and `EnemyControl` for enemy armies
    * This will automticly create an `Army` script and a `BoxCollider2D` (hitbox for attacks)
    * then, on the Inspector of the control script open the `PossibleFormations` list and drag there the formations from the formation folder
  * ***To see an example of armies that are set up check the player and Immortal prefabs***  
* The win and lose conditions are now verified in `LevelManager`, the player loses if they get pushed too far back, and they win if they reach a certain point ahead. These points are to be set in the Inspector of the LevelManager object in the scene.
* `Formations` are now `ScriptableObjects` where you can set each one's modifiers in the inspector after you created in.
  * `Formations` hold modifiers (between 0-2x) that the `Army` scripts apply to the Stats variables inside when it's time to use them.
* Make sure that every `Control` class in an object has atleast an `Idle` formation in it's list.
* Make sure every enemy army has their speed stat in the Army component set to a negative value so they go left instead of right.



* **Controls are:**
  * Brace: *Left-Arrow*
  * Cover: *Down-Arrow*
  * March: *Right-Arrow*
  * Charge: *Up-Arrow*
  * Attack: *X*
 
### Possible Problems not dealt with
