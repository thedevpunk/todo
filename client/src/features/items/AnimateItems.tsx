import React, { useEffect, useState, useRef } from 'react';

function usePrevious(value: any) {
    const ref = useRef();
    useEffect(() => {
        ref.current = value;
    });
    return ref.current;
}

const calculateBoundingBoxes = (children: any) => {
    const boundingBoxes: any = {};
    React.Children.forEach(children, (child: any) => {
        const domNode = child.ref.current;
        const nodeBoundingBox = domNode.getBoundingClientRect();

        boundingBoxes[child.key] = nodeBoundingBox;
    });

    return boundingBoxes;
}

interface IProps {
    children: any;
}

export const AnimateItems: React.FC<IProps> = ({ children }) => {
    const [boundingBox, setBoundingBox] = useState<any>({});
    const [prevBoundingBox, setPrevBoundingBox] = useState<any>({});
    const prevChildren = usePrevious(children);

    useEffect(() => {
        const newBoundingBox = calculateBoundingBoxes(children);
        setBoundingBox(newBoundingBox);
    }, [children]);

    useEffect(() => {
        const prevBoundingBox = calculateBoundingBoxes(prevChildren);
        setPrevBoundingBox(prevBoundingBox);
    }, [prevChildren]);

    useEffect(() => {
        const hasPrevBoundingBox = Object.keys(prevBoundingBox).length;

        if (hasPrevBoundingBox) {
            React.Children.forEach(children, (child) => {
                const domNode = child.ref.current;
                const firstBox = prevBoundingBox[child.key];
                const lastBox = boundingBox[child.key];
                const changeInY = firstBox.top - lastBox.top;

                if (changeInY) {
                    requestAnimationFrame(() => {
                        domNode.style.transform = `translateY(${changeInY}px)`;
                        domNode.style.transition = 'transform 0s';

                        requestAnimationFrame(() => {
                            domNode.style.transform = '';
                            domNode.style.transition = 'transform 500ms';
                        });
                    });
                }
            });
        }
    }, [boundingBox, prevBoundingBox, children]);

    return children;
}