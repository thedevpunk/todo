import React from 'react';
import { IItem } from '../../app/models/item';
import './Items.scss';

interface IProps {
    item: IItem;
}

export const Item: React.FC<IProps> = ({ item }) => {


    return (
        <div className="item">
            <div className="checkbox">
                <input type="checkbox" id={`itemCheckbox${item.id}`} defaultChecked={item.isDone}/>
                <label htmlFor={`itemCheckbox${item.id}`}></label>
            </div>
            <div>{item.title}</div>
        </div>
    )
}
