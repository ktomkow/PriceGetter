import React from 'react';

import strings from "../../localization/strings";

const PageNotFound = () => {
    return (
        <div>
            <h1>{strings.NOT_FOUND.MESSAGE} </h1>
            <a href="/home">Go home</a>
        </div>
    );
};

export default PageNotFound;