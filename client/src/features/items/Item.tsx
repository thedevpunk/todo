import React, { forwardRef } from 'react';
import { IItem } from '../../app/models/item';
import './Items.scss';

interface IProps {
    item: IItem;
    checkItem: (id: string) => void;
}

export const Item = forwardRef<HTMLDivElement, IProps>(({ item, checkItem }, ref) => {

    return (
        <div ref={ref} className={`item${item.isDone ? ' item-checked' : ''}`}>
            <div className="checkbox">
                <input type="checkbox" id={`itemCheckbox${item.id}`} defaultChecked={item.isDone} onChange={() => checkItem(item.id)} />
                <label htmlFor={`itemCheckbox${item.id}`}></label>
            </div>
            <div>{item.title}</div>
        </div>
    )
})
