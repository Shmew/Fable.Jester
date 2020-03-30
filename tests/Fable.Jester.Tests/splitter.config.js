const path = require("path");
const testsDir = path.join(__dirname, "../../dist/tests");

module.exports = {
    allFiles: true,
    entry: path.join(__dirname, "./Fable.Jester.Tests.fsproj"),
    outDir: testsDir,
    babel: {
        plugins: [
            "@babel/plugin-transform-modules-commonjs"
        ]
    },
    onCompiled() {
        const snapshotLoader = require(path.join(testsDir, "Fable.Jester.SnapshotLoader/SnapshotLoader"));
        snapshotLoader.copySnaps(__dirname, this.outDir)
    }
};