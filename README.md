# 🌧️ PixelRain

**PixelRain** is a high-efficiency, lossless compression system for large sequences of grayscale images. Designed for industrial and scientific applications, it exploits both spatial and temporal redundancy by compressing **spatiotemporal pixel blocks** into compact binary streams.

---

## 🔍 Motivation

When capturing thousands of grayscale images — such as photos of electronic components from reels — traditional image storage methods are wasteful. PixelRain rethinks the storage format by treating each pixel (or small region) as a **time series**, compressing grouped blocks over time to dramatically reduce storage requirements while maintaining **random access** capabilities.

---

## 🎯 Key Features

- 📦 **Lossless compression** of grayscale image sequences
- 🧱 **Block-based architecture** for fast access and parallelism
- 🧠 Exploits **spatial + temporal redundancy** in image stacks
- 🚀 Built in **C#** for high performance and portability
- 🗂️ Designed to store **tens of thousands** of frames efficiently

---

## 🧰 Architecture Overview

PixelRain divides the full image sequence into fixed-size **spatiotemporal blocks**:

```

Sequence shape: (time, width, height)
Block shape:    (T=100, W=8, H=8) → 6400 values

````

Each block is flattened in raster order (pixel-major) and compressed as a single unit. Blocks are indexed by time and spatial coordinates for fast, random access.

---

## 📁 File Structure

- `PixelRain.Core/` – Core data structures and compression logic
- `PixelRain.Codecs/` – Compression wrappers (e.g. Zstd, Blosc)
- `PixelRain.Storage/` – I/O system, file format, indexing
- `PixelRain.Tools/` – CLI utilities (e.g., encode/decode, inspect)
- `examples/` – Example encoder/decoder usage with synthetic or real data

---

## 🧪 Getting Started

### Prerequisites

- [.NET 7+](https://dotnet.microsoft.com/)
- [Zstd native library](https://facebook.github.io/zstd/) (optional)

### Build

```bash
dotnet build
````

### Example Usage

```csharp
var encoder = new BlockEncoder(blockShape: (100, 8, 8));
encoder.AddFrame("frame_00001.png");
...
encoder.Save("output.pixelrain");
```

---

## 📊 Benchmark Goals

| Test Set       | Uncompressed Size | PixelRain (target) | Compression Ratio |
| -------------- | ----------------- | ------------------ | ----------------- |
| 100k x 512×512 | \~25 GB           | \~1–3 GB           | 8× to 25×         |

Benchmarks pending. Contributions welcome.

---

## 📦 Roadmap

* [ ] Block-based compressor core
* [ ] File format with index
* [ ] Parallel compression
* [ ] Decoder and viewer
* [ ] Integration with ML pipelines
* [ ] Zarr/TileDB export compatibility

---

## 🤝 Contributing

Contributions are welcome! If you have ideas for better compressors, access methods, or format support (e.g., Zarr or TIFF export), open an issue or pull request.

---

## 📄 License

MIT License © 2025 Pavel Tatarintsev

---

## 📬 Contact

For questions, feel free to open an issue or reach out via GitHub Discussions.
