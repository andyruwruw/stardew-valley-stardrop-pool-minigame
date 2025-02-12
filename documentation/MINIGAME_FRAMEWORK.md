# SDV Minigame Framework

In order to write Stardrop Pool, I wrote my own little framework for managing rendering objects and scenes.

## Entity

Simular to web development in HTML, entities (or elements) are defined in relation to one other through a parent-child relationship. This allows for easy management of objects in a scene.

A child of an element drawn within it's bounds, and subsequent entities are drawn below.

Entities can be defined as rows, which will display elements horizontally, or columns, which will display elements vertically.
