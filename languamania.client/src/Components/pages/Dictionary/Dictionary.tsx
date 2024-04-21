import Button from "../../common/Button/Button";
import "./styles/index.scss";

export default function Dictionary() {
    const wordsData = [
        {
            id: 1,
            name: "Black",
            language: "English",
        },
        {
            id: 2,
            name: "Green",
            language: "English",
        },
    ];
    const divStyles: React.CSSProperties = {
        display: "flex",
        flexDirection: "column",
        height: "100%",
        alignContent: "center",
        justifyContent: "start",
        backgroundColor: "rgb(253 253 253)",
    };

    const uiItems = wordsData.map((w) => (
        <li className="dictionary__item" key={w.id}>
            Word: <i>{w.name}</i>. Language: <i>{w.language}</i>
            <Button
                className="dictionary__button"
                onClick={() => alert(w.name)}
                text="Display the word name"
            />
        </li>
    ));

    return (
        <div className="dictionary" style={divStyles}>
            <h2 className="dictionary__heading">Words</h2>
            <ul className="dictionary__list">{uiItems}</ul>
        </div>
    );
}
