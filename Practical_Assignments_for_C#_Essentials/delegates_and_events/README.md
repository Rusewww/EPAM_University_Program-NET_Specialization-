# Delegates and events

Task Delegates and events reffers to task Collections

## Task Collections
<details><summary>Collections description</summary>

To create generic type **CustomArray** – one dimensional array with random index range 

**CustomArray** is a collection – array of random type values with fixed length and with an original index that is specified by the user. 

Example 1: an array of 20 elements length, array values – symbols, index starts with 18. 

Example 2: an array of 10 elements length, array values – objects of class Animals, index starts with -5. 

Values of random type can be located in the array, custom first index and the number of elements in the array should be specified while creating. The length and range of indexes cannot be changed after creating. Values of array elements can be set while creating the array and later with the help of the indexer. 

Initial and finite index, array length, array elements in the form of standard array Array that starts with 0 can be obtained from the array. 

**CustomArray** should be able to use operator foreach and other constructions that are oriented to the presence of numerator in class. 

In **CustomArray** implementation of the following functionality is required: 

- Creating of empty user array with specified first index and specified number of elements. 
- Creating of user array based on standard existing array or other collection. 
- Creating of an array with the specified first index based on the values of the array params. 
- Receiving first, last indexes, length, values in form of standard array with first index 0. 
- Access to writing and reading element based on a predetermined correct index. 
- Generating exceptions, specified in xml-comments to class methods. 
- Receiving numerator from array for operator foreach. 

</details>

## Task Delegates and events
To add the following new functionalities to the project created in task Collections: 

Include two events in the **CustomArray** type: 

- The **OnChangeElement** event occurs when the indexer changes the element value (if the old and new element values match, the event is not raised) 

- The **OnChangeEqualElement** event occurs if a value equal to the index of the changed element is written to the element (if the old and new values of the element match, the event is not raised) 
 
Use the **ArrayHandler** delegate to create the event. 

The event handler takes two parameters: an object **sender** - a reference to the **CustomArray** instance that generated the event, and an event argument **ArrayEventArgs <T> e**. In the event argument, write in the **Id** field the index by which the user changes the element of the **CustomArray** array, in the **Value** field - the new value of the element by the Id index, in the **Message** field - an arbitrary string message. 
