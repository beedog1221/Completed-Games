function FishFood::onLevelLoaded(%this, %scenegraph)
{
   %this.startPosition = %this.getPosition();
   %this.setLinearVelocityY(getRandom(%this.minSpeed, %this.maxSpeed));
}

function FishFood::onWorldLimit(%this, %mode, %limit)
{
   if(%limit $= "bottom")
   {
      %this.spawn();
   }
}

function FishFood::spawn(%this)
{
   %this.setPosition(%this.startPosition);
   %this.setLinearVelocityY(getRandom(%this.minSpeed, %this.maxSpeed));
}

function FishFood::onCollision(%srcObj, %dstObj, %srcRef, %dstRef, %time, %normal, %contactCount, %contacts)
{
   if(%dstObj.class $= "PlayerFish")
   {
      %srcObj.spawn();
   }
}
