export default function Words() {
    const wordsData = [{
        id: 1,
        name: "Black",
        language: "English"
    },
    {
        id: 2,
        name: "Green",
        language: "English"
    }]
    const divStyles: React.CSSProperties = { display: 'flex', flexDirection: 'column', height: '100%', alignContent: 'center', justifyContent: 'start', backgroundColor: 'rgb(253 253 253)' };
    const pStyle: React.CSSProperties = { marginLeft: '7px' };
    const uiItems = wordsData.map(w =>
        <li key={w.id}>
            Word: <i>{w.name}</i>. Language: <i>{w.language}</i>
        </li>
    );

    return (
        <div style={divStyles}>
            <p style={pStyle}>Words</p>
            <ul style={{margin: 0}} >
                {uiItems}
            </ul>
        </div>
    );
}