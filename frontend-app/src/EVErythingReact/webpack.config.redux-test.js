const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');

module.exports = {
    mode: 'development',
    context: __dirname,
    target: 'web',
    devtool: 'source-map',
    devServer: {
        contentBase: './redux-test-dist',
        port: 3000
    },
    resolve: {
        extensions: [".ts", ".tsx", ".js", ".json"]
    },
    entry: {
        app: ["babel-polyfill", "./eve-redux-index.ts"]
    },
    output: {
        filename: '[name].js',
        chunkFilename: 'js/[name].bundle.js',
        publicPath: '',
        path: path.resolve(__dirname, 'redux-test-dist')
    },
    plugins: [
        new webpack.DefinePlugin({
            'process.env.NODE_ENV': JSON.stringify(process.env.NODE_ENV || 'development')
        }),
        new HtmlWebpackPlugin({
            "template": "./src/index.html",
            "filename": "./index.html"
        }),
        new CopyWebpackPlugin([
            { from: './src/manifest.json' }
        ])
    ],
    module: {
        rules: [
            { test: /\.tsx?$/, loader: "ts-loader" },
            { test: /(\.css|\.sass|\.scss)$/, loaders: ['style-loader', 'css-loader', 'sass-loader'] },
            { test: /\.(jpe?g|png|gif)$/i, loader: 'file-loader?name=assets/images/[name].[ext]' },
            { test: /\.ico$/, loader: 'file-loader?name=[name].[ext]' },
            { test: /\.eot(\?v=\d+.\d+.\d+)?$/, loader: 'file-loader?prefix=font/&limit=5000&name=assets/fonts/[name].[ext]' },
            { test: /\.(woff|woff2)$/, loader: 'file-loader?prefix=font/&limit=5000&name=assets/fonts/[name].[ext]' },
            { test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, loader: 'file-loader?limit=10000&mimetype=application/octet-stream&name=assets/fonts/[name].[ext]' },
            { test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, loader: 'file-loader?limit=10000&mimetype=image/svg+xml&name=assets/svgs/[name].[ext]' }
        ]
    },
    node: {
        console: false,
        global: true,
        process: true,
        Buffer: false,
        setImmediate: false
    }
};
