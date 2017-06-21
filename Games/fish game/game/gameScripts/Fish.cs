function Fish::onLevelLoaded(%this, %scenegraph)
{
   %this.setLinearVelocityX(%this.getSpeed());
}

function Fish::getSpeed(%this)
{
   return getRandom(%this.minSpeed, %this.maxSpeed);
}

function Fish::onWorldLimit(%this, %mode, %limit)
{
   switch$(%limit)
   {
      case "left":
         %this.setFlipX(false);
         %this.setLinearVelocityX(%this.getSpeed());
         %this.reposition();

      case "right":
         %this.setFlipX(true);
         %this.setLinearVelocityX(-%this.getSpeed());
         %this.reposition();
   }
}
function Fish::reposition(%this)
{
   %this.setPositionY(getRandom(%this.minPosition, %this.maxPosition));
}
