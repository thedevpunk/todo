import React, { useState } from 'react';
import axios from 'axios';
import { IItem } from '../../app/models/item';
import { Item } from './Item';

const testDataItems = [
    {
        "id": "09fe33ed-d8c3-4385-a39e-da7a61d4ca9b",
        "title": "do some home work",
        "isDone": false,
        "description": "something over here and something over there"
    },
    {
        "id": "38dc5860-d49c-443d-8cef-36339a55ee5b",
        "title": "making the laudry",
        "isDone": false,
        "description": "something over here and something over there"
    },
    {
        "id": "940034df-523a-43e6-b57a-90b4fe524dfe",
        "title": "grabbing a book",
        "isDone": false,
        "description": "something over here and something over there"
    },
    {
        "id": "4de327e5-34a1-4591-8a6c-ea5315021eb5",
        "title": "watering the plants",
        "isDone": false,
        "description": "something over here and something over there"
    }
];



export const Dashboard = () => {
    const [items, setItems] = useState<IItem[]>(testDataItems);




    const handleCheckItem = (id: string) => {
        
        const itemToCheck = items.find(i => i.id === id);
        console.log(itemToCheck);
        if (itemToCheck) {
            itemToCheck.isDone = !itemToCheck.isDone
            if (itemToCheck.isDone) {
                const newItems = [...items.filter(i => i.id !== id), itemToCheck];
                setItems(newItems);
            } else {
                const itemsUnchecked = [...items.filter(i => i.isDone === false)];
                const itemsChecked = [...items.filter(i => i.isDone === true)];

                setItems([...itemsUnchecked, ...itemsChecked]);
            }
        }
    }

    return (
        <div className="dashboard">
            {items.map(item => (
                <Item
                    key={item.id}
                    item={item}
                    checkItem={handleCheckItem}
                />
            ))}
        </div>
    )
}
