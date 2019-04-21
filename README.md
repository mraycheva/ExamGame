# Overview

A simple console application implementing the logic of two heroes fighting.

The assignment is, as follows:

## Game rules

The game goes **in turns**. The two heroes fight each other in turns. Hero 1 attacks Hero 2. If Hero 2 survives the attack, he attacks back. The game continues **until one of the heroes dies**.

## Attack mechanism

The **attacking** hero **unleashes pure damage**, measured in points. The **attacked** hero **takes some or all of the damage, depending on his skills**.

## Specifications

All heroes have **attributes**:

* **Health points** – when health points go zero or lower, the hero is dead;
* **Attack points**;
* **Armour points**.

When **attacking**, all heroes **unleash randomly between 80 % and 120 % of their attack points** as **raw damage**.

When **defending**, all heroes **take actual damage, reduced randomly with between 80 % and 120% of their armour points**. The actual damage received **reduces their health points**. When the health points become zero or less, the hero is dead.

There are at least two **types of heroes**:
*	**Warrior**:
    * nothing special about him;
*	**Knight**:
    *	when **defending**, has a **20 % chance to** completely block the attack and **receive no damage**;
    *	when **attacking**, has a **10 % chance to do 200 % damage**;
*	**Assassin**:
    *	when **attacking**, has a **30 % chance to do 300 % damage**;
*	**Monk**:
    *	when **defending**, has a **30 % chance to** avoid the attack and **receive no damage**.

## Tasks:

*	Model and implement class **GameEngine**, which **implements the logic of the game**. The class **must not implement any user interface interaction**. It must expose the necessary properties and events so that any type of user interface can be implemented with it: console app, WinForms, WPF, etc.
*	Model and implement classes **Hero**, **Warrior**, **Knight**, **Assassin**, **Monk**.
*	Write **a program to test your classes**. It can be a Console, WinForms, WPF or even a web application.
*	Bonus points – think of and implement **additional hero classes**. 
