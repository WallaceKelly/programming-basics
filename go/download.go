package main

import (
	"fmt"
	"io/ioutil"
	"net/http"
	"sync"
	"time"
)

var wg sync.WaitGroup

func download_page(url string) {
	fmt.Println("Downloading", url)
	resp, _ := http.Get(url)
	defer resp.Body.Close()
	body, _ := ioutil.ReadAll(resp.Body)
	bodyText := string(body)
	fmt.Println("Downloaded ", url, "in", len(bodyText), "bytes.")

	wg.Done()
}

func main() {
	start := time.Now()

	wg.Add(5)
	go download_page("https://en.wikipedia.org/")
	go download_page("https://stackoverflow.com/")
	go download_page("https://golang.org/")
	go download_page("https://github.com/")
	go download_page("https://google.com/")

	wg.Wait()

	fmt.Println(time.Since(start))
}

/*
 */
