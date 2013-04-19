﻿namespace Demo {
	using System;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using ImmutableObjectGraph;

	class Program {
		static void Main(string[] args) {
			var apple = Fruit.Create(color: "red", skinThickness: 3);

			ICloneable appleTree = new Tree("Apple tree");
			
			var greenApple = apple.With(color: "green", growsOn: Optional.For(appleTree));
			greenApple = apple.With(color: "green", growsOn: (Tree)appleTree);
			var greenAppleWithDefaultThickness = greenApple.With(skinThickness: 0);

			ImmutableList<Fruit> immutableFruits = ImmutableList.Create(apple);
			IImmutableList<Fruit> fruits = immutableFruits;

			var basket = Basket.Create(contents: immutableFruits, size: 5);
			basket = Basket.Create(contents: Optional.For(fruits), size: 5);
			basket = Basket.Create().WithContents(fruits).WithSize(5);

			var appleBuilder = apple.ToBuilder();
			appleBuilder.Color = "yellow";
			var yellowApple = appleBuilder.ToImmutable();
			Console.WriteLine("You have a {0} apple with {1} skin thickness", apple.Color, apple.SkinThickness);
		}
	}
}