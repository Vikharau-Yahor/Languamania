import { useState, useEffect } from 'react';
import Button from "../../common/Button/Button";
import "./styles/index.scss";

interface Word {
    id: number;
    text: string;
    language: string;
}

export default function Dictionary() {
    const [words, setWords] = useState<Word[]>([]);

    useEffect(() => {
        populateWordsData();
    }, []);
   
    let wordsSection: JSX.Element = <p><b>No Data</b></p>

    if (words && words.length > 0) {
        const uiItems = words.map((w) => (
            <li className="dictionary__item" key={w.id}>
                Word: <i>{w.text}</i>. Language: <i>{w.language}</i>
                <Button
                    className="dictionary__button"
                    onClick={() => alert(w.text)}
                    text="Display the word text"
                />
            </li>
        ));

        wordsSection = <ul className="dictionary__list">{uiItems}</ul>
    }
    return (
        <div className="dictionary">
            <h2 className="dictionary__heading">Words</h2>
            {wordsSection}
        </div>
    );

    async function populateWordsData() {

        const response = await fetch('api/translationItems');
        const data = await response.json();
        //const data = [
        //    {
        //        id: 1,
        //        text: "Black",
        //        language: "English",
        //    },
        //    {
        //        id: 2,
        //        text: "Green",
        //        language: "English",
        //    },
        //];
        setWords(data);
    }
}
