import React from 'react';
import { IItem } from '../../app/models/item';
import './Items.scss';

interface IProps {
    item: IItem;
}

export const Item: React.FC<IProps> = ({ item }) => {


    return (
        <div style={{ display: 'flex' }}>
            <div className="round">
                <input type="checkbox" id="checkbox" defaultChecked={item.isDone}/>
                <label htmlFor="checkbox"></label>
            </div>
            <div>{item.title}</div>
        </div>
    )
}
