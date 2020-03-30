const path = require("path");

module.exports = {
    allFiles: true,
    entry: path.join(__dirname, "./Fable.Jest.ReactTestingLibrary.Tests.fsproj"),
    outDir: path.join(__dirname, "../../dist/tests/RTL"),
    babel: {
        plugins: ["@babel/plugin-transform-modules-commonjs"],
    }
};