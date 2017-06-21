function PlayerFish::onLevelLoaded(%this, %scenegraph)
{
   $FishPlayer = %this;

   moveMap.bindCmd(keyboard, "w", "fishPlayerUp();", "fishPlayerUpStop();");
   moveMap.bindCmd(keyboard, "s", "fishPlayerDown();", "fishPlayerDownStop();");
   moveMap.bindCmd(keyboard, "a", "fishPlayerLeft();", "fishPlayerLeftStop();");
   moveMap.bindCmd(keyboard, "d", "fishPlayerRight();", "fishPlayerRightStop();");
   moveMap.bindCmd(keyboard, "space", "fishPlayerBoost();", "fishPlayerBoostStop();");

}

function fishPlayerUp()
{
   $FishPlayer.setLinearVelocityY( -$FishPlayer.vSpeed  );
}

function fishPlayerDown()
{
   $FishPlayer.setLinearVelocityY( $FishPlayer.hSpeed  );
}

function fishPlayerLeft()
{
   $FishPlayer.moveLeft = true;
   $FishPlayer.updateMovement();

}

function fishPlayerRight()
{
  $FishPlayer.moveRight = true;
   $FishPlayer.updateMovement();
}

function fishPlayerUpStop()
{
   $FishPlayer.setLinearVelocityY( 0 );
}

function fishPlayerDownStop()
{
   $FishPlayer.setLinearVelocityY( 0 );
}

function fishPlayerLeftStop()
{
   $FishPlayer.moveLeft = false;
   $FishPlayer.updateMovement();
}

function fishPlayerRightStop()
{
   $FishPlayer.moveRight = false;
   $FishPlayer.updateMovement();
}

function PlayerFish::updateMovement(%this)
{
   if(%this.moveLeft)
   {
      $FishPlayer.setFlipX(true);
      $FishPlayer.setLinearVelocityX( -$FishPlayer.hSpeed );
   }
   
   if(%this.moveRight)
   {
      $FishPlayer.setFlipX(false);
      $FishPlayer.setLinearVelocityX( $FishPlayer.hSpeed );
   }

   if(!%this.moveLeft && !%this.moveRight)
   {
      %this.setLinearVelocityX( 0 );
   }
}
function fishPlayerBoost()
{
   %flipX = $FishPlayer.getFlipX();


   if(!%flipX)
   {
      %hSpeed = $FishPlayer.hSpeed * 3;
   } else
   {
      %hSpeed = -$FishPlayer.hSpeed * 3;
   }

   $FishPlayer.setLinearVelocityX(%hSpeed);
}

function PlayerFish::modifyLife(%this, %dmg)
{
   %this.life += %dmg;


   if(%this.life > 100)
   {
      %this.life = 100;
   } else if (%this.life < 0)
   {
      %this.life = 0;
   }


   if(%this.life <= 30)
   {
      %this.dead();
   } else
   {
      %this.updateLifeSize();
   }
}

function PlayerFish::updateLifeSize(%this)
{
   %lifeMultiplier = %this.life / 100;
   %newWidth = %this.maxWidth * %lifeMultiplier;
   %newHeight = %this.maxHeight * %lifeMultiplier;

   %this.setSize(%newWidth, %newHeight);
}

function PlayerFish::dead(%this)
{
   %this.setFlipY(true);
   %this.setLinearVelocityY(-10);
   %this.dead = true;
}

function PlayerFish::lowerLife(%this)
{
   %this.modifyLife(%this.lifeDrain);

   if(!%this.dead)
   {
      %this.schedule(500, "lowerLife");
   }
}

if(%this.dead)
    return;
